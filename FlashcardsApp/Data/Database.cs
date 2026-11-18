using Microsoft.Data.SqlClient;

namespace FlashcardsApp;

// Tạo cơ sở dữ liệu Flashcards trên SQL Server Express của máy, 9 bảng và dữ liệu mẫu. Việc của #4.
// Bảng, cột, khóa chính, khóa ngoại: xem docs/03-database.md và ảnh docs/assets/data/data.png.
// Các chỗ ghi "TODO (#4)" là phần còn phải viết. Trong Visual Studio mở View → Task List để thấy hết.
public static class Database
{
    // Máy nào đặt tên khác .\SQLEXPRESS thì sửa ở đây, nhưng đừng commit dòng đã sửa
    const string Server = @".\SQLEXPRESS";

    // Mọi lớp ...Store mở kết nối bằng chuỗi này
    public static string ConnectionString =>
        $"Server={Server};Database=Flashcards;Trusted_Connection=True;TrustServerCertificate=True";

    static string MasterConnectionString =>
        $"Server={Server};Database=master;Trusted_Connection=True;TrustServerCertificate=True";

    // Gọi một lần trong Program.cs, trước khi mở hộp đăng nhập
    public static void EnsureCreated()
    {
        using (var master = new SqlConnection(MasterConnectionString))
        {
            master.Open();
            using var check = new SqlCommand("SELECT DB_ID('Flashcards')", master);
            if (check.ExecuteScalar() is not DBNull) return; // đã có thì thôi
            using var create = new SqlCommand("CREATE DATABASE Flashcards", master);
            create.ExecuteNonQuery();
        }

        using var conn = new SqlConnection(ConnectionString);
        conn.Open();
        using var cmd = new SqlCommand(CreateTablesSql + SampleDataSql, conn);
        cmd.ExecuteNonQuery();
    }

    const string CreateTablesSql = """
        CREATE TABLE Users (
            Id           INT IDENTITY PRIMARY KEY,           -- máy tự đánh số
            Username     NVARCHAR(50)  NOT NULL UNIQUE,
            PasswordHash VARCHAR(64)   NOT NULL,
            Role         VARCHAR(10)   NOT NULL DEFAULT 'User' CHECK (Role IN ('Admin', 'User')),
            Rating       INT           NOT NULL DEFAULT 0,
            CreatedAt    DATETIME2     NOT NULL DEFAULT SYSDATETIME()
        );

        CREATE TABLE Courses (
            Id          INT IDENTITY PRIMARY KEY,
            Title       NVARCHAR(100) NOT NULL,
            Description NVARCHAR(500) NOT NULL DEFAULT ''
        );

        CREATE TABLE Folders (
            Id          INT IDENTITY PRIMARY KEY,
            Name        NVARCHAR(100) NOT NULL,
            OwnerId     INT NOT NULL REFERENCES Users(Id),
            IsDefault   BIT NOT NULL DEFAULT 0,
            CourseId    INT NULL REFERENCES Courses(Id),
            LessonOrder INT NULL,
            StartDate   DATE NULL,
            EndDate     DATE NULL,
            UNIQUE (OwnerId, Name)                            -- một người không có 2 thư mục trùng tên
        );

        CREATE TABLE Flashcards (
            Id                 INT IDENTITY PRIMARY KEY,
            FolderId           INT NOT NULL REFERENCES Folders(Id),
            Word               NVARCHAR(100) NOT NULL,
            Meaning            NVARCHAR(255) NOT NULL,
            Pronunciation      NVARCHAR(100) NOT NULL DEFAULT '',
            Example            NVARCHAR(500) NOT NULL DEFAULT '',
            ExampleTranslation NVARCHAR(500) NOT NULL DEFAULT '',
            MemoryNote         NVARCHAR(500) NOT NULL DEFAULT ''
        );

        CREATE TABLE CardProgress (
            UserId          INT NOT NULL REFERENCES Users(Id),
            CardId          INT NOT NULL REFERENCES Flashcards(Id) ON DELETE CASCADE, -- xóa từ thì xóa luôn mức nhớ
            LastRating      INT NOT NULL,
            WrongCount      INT NOT NULL DEFAULT 0,
            LastWrongAnswer NVARCHAR(100) NOT NULL DEFAULT '',
            PRIMARY KEY (UserId, CardId)
        );

        CREATE TABLE StudyDays (
            UserId INT  NOT NULL REFERENCES Users(Id),
            Day    DATE NOT NULL,
            PRIMARY KEY (UserId, Day)
        );

        CREATE TABLE DailyChallenges (
            Day      DATE PRIMARY KEY,
            FolderId INT NOT NULL REFERENCES Folders(Id) ON DELETE CASCADE
        );

        CREATE TABLE ChallengeResults (
            UserId  INT  NOT NULL REFERENCES Users(Id),
            Day     DATE NOT NULL,
            Score   INT  NOT NULL DEFAULT 0,
            Total   INT  NOT NULL,
            Seconds INT  NOT NULL DEFAULT 0,
            PRIMARY KEY (UserId, Day)                         -- mỗi người mỗi ngày một lượt
        );

        CREATE TABLE RushResults (
            Id       INT IDENTITY PRIMARY KEY,
            UserId   INT NOT NULL REFERENCES Users(Id),
            Score    INT NOT NULL,
            PlayedAt DATETIME2 NOT NULL DEFAULT SYSDATETIME()
        );
        """;

    // 3 tài khoản mẫu: admin mật khẩu admin123 (docs/04), lan và minh mật khẩu 123456
    //   Id 1 admin (Admin), Id 2 lan (User), Id 3 minh (User)
    // Mã hóa bằng HASHBYTES cho khớp với UserStore.HashPassword
    const string SampleDataSql = """
    DECLARE @today     DATE = CAST(GETDATE() AS DATE);
    DECLARE @yesterday DATE = DATEADD(DAY, -1, CAST(GETDATE() AS DATE));

    -- Tài khoản
    INSERT INTO Users (Username, PasswordHash, Role) VALUES
        ('admin', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin:admin123'), 2), 'Admin'),
        ('lan',   CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'lan:123456'),   2), 'User'),
        ('minh',  CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'minh:123456'),  2), 'User');
    DECLARE @admin INT = (SELECT Id FROM Users WHERE Username = 'admin');
    DECLARE @lan   INT = (SELECT Id FROM Users WHERE Username = 'lan');
    DECLARE @minh  INT = (SELECT Id FROM Users WHERE Username = 'minh');

    -- Mỗi người một thư mục "Chưa phân loại"
    INSERT INTO Folders (Name, OwnerId, IsDefault) VALUES
        (N'Chưa phân loại', @admin, 1), (N'Chưa phân loại', @lan, 1), (N'Chưa phân loại', @minh, 1);

    -- Khóa học 3 bài (3 thư mục của admin)
    INSERT INTO Courses (Title, Description) VALUES (N'Tiếng Anh hằng ngày', N'Từ vựng hằng ngày');
    DECLARE @course INT = SCOPE_IDENTITY();
    INSERT INTO Folders (Name, OwnerId, CourseId, LessonOrder) VALUES
        (N'Bài 1 · Daily life', @admin, @course, 1),
        (N'Bài 2 · At work',    @admin, @course, 2),
        (N'Bài 3 · Travel',     @admin, @course, 3);
    DECLARE @b1 INT = (SELECT Id FROM Folders WHERE CourseId = @course AND LessonOrder = 1);
    DECLARE @b2 INT = (SELECT Id FROM Folders WHERE CourseId = @course AND LessonOrder = 2);
    DECLARE @b3 INT = (SELECT Id FROM Folders WHERE CourseId = @course AND LessonOrder = 3);

    -- Thư mục theo mùa
    INSERT INTO Folders (Name, OwnerId, StartDate, EndDate) VALUES
        (N'Giáng sinh', @admin, '20261201', '20261231'),
        (N'Tết',        @admin, '20270115', '20270215');
    DECLARE @xmas INT = (SELECT Id FROM Folders WHERE OwnerId = @admin AND Name = N'Giáng sinh');
    DECLARE @tet  INT = (SELECT Id FROM Folders WHERE OwnerId = @admin AND Name = N'Tết');

    -- 30 từ của khóa học (mỗi bài 10 từ)
    INSERT INTO Flashcards (FolderId, Word, Meaning, Pronunciation, Example, ExampleTranslation, MemoryNote) VALUES
        (@b1, N'make a decision', N'đưa ra quyết định', N'/meɪk ə dɪˈsɪʒən/', N'I need to make a decision today.', N'Tôi cần đưa ra quyết định hôm nay.', N'Dùng make với decision, không dùng do.'),
        (@b1, N'take a break', N'nghỉ giải lao', N'/teɪk ə breɪk/', N'Let us take a break for ten minutes.', N'Hãy nghỉ giải lao mười phút.', N'Dùng take với break.'),
        (@b1, N'make progress', N'tiến bộ', N'/meɪk ˈprəʊɡres/', N'You are making progress every week.', N'Bạn tiến bộ mỗi tuần.', N'Dùng make với progress.'),
        (@b1, N'do homework', N'làm bài tập về nhà', N'/duː ˈhəʊmwɜːk/', N'I do my homework after dinner.', N'Tôi làm bài tập sau bữa tối.', N'Dùng do với homework.'),
        (@b1, N'pay attention to', N'chú ý đến', N'/peɪ əˈtenʃn tuː/', N'Please pay attention to the teacher.', N'Hãy chú ý lắng nghe giáo viên.', N'Đi với giới từ to.'),
        (@b1, N'look forward to', N'mong đợi', N'/lʊk ˈfɔːwəd tuː/', N'I look forward to meeting you.', N'Tôi mong được gặp bạn.', N'To ở đây đi với V-ing.'),
        (@b1, N'give up', N'từ bỏ', N'/ɡɪv ʌp/', N'Never give up on your goals.', N'Đừng bao giờ từ bỏ mục tiêu.', N''),
        (@b1, N'depend on', N'phụ thuộc vào', N'/dɪˈpend ɒn/', N'It depends on the weather.', N'Điều đó phụ thuộc vào thời tiết.', N'Đi với giới từ on.'),
        (@b1, N'curious', N'tò mò, ham tìm hiểu', N'/ˈkjʊəriəs/', N'She is curious about the world.', N'Cô ấy tò mò về thế giới.', N''),
        (@b1, N'improve', N'cải thiện', N'/ɪmˈpruːv/', N'I practice every day to improve my English.', N'Tôi luyện tập mỗi ngày để cải thiện tiếng Anh.', N''),

        (@b2, N'confident', N'tự tin', N'/ˈkɒnfɪdənt/', N'He feels confident when speaking English.', N'Anh ấy cảm thấy tự tin khi nói tiếng Anh.', N''),
        (@b2, N'achieve', N'đạt được', N'/əˈtʃiːv/', N'Small steps help you achieve your goals.', N'Những bước nhỏ giúp bạn đạt được mục tiêu.', N''),
        (@b2, N'borrow', N'mượn (từ ai đó)', N'/ˈbɒrəʊ/', N'Can I borrow your pen?', N'Tôi mượn bút của bạn được không?', N'Borrow là nhận, lend là đưa.'),
        (@b2, N'lend', N'cho mượn', N'/lend/', N'Can you lend me some money?', N'Bạn cho tôi mượn ít tiền được không?', N''),
        (@b2, N'knowledge', N'kiến thức', N'/ˈnɒlɪdʒ/', N'Reading gives you a lot of knowledge.', N'Đọc sách mang lại nhiều kiến thức.', N'Danh từ không đếm được, không thêm s.'),
        (@b2, N'environment', N'môi trường', N'/ɪnˈvaɪrənmənt/', N'We must protect the environment.', N'Chúng ta phải bảo vệ môi trường.', N''),
        (@b2, N'experience', N'kinh nghiệm, trải nghiệm', N'/ɪkˈspɪəriəns/', N'She has five years of experience.', N'Cô ấy có năm năm kinh nghiệm.', N''),
        (@b2, N'opportunity', N'cơ hội', N'/ˌɒpəˈtjuːnəti/', N'This job is a great opportunity.', N'Công việc này là cơ hội tuyệt vời.', N''),
        (@b2, N'responsible', N'chịu trách nhiệm', N'/rɪˈspɒnsəbl/', N'He is responsible for the project.', N'Anh ấy chịu trách nhiệm cho dự án.', N'Đi với for.'),
        (@b2, N'available', N'có sẵn, rảnh', N'/əˈveɪləbl/', N'Are you available tomorrow?', N'Ngày mai bạn có rảnh không?', N''),

        (@b3, N'compare', N'so sánh', N'/kəmˈpeər/', N'Do not compare yourself with others.', N'Đừng so sánh bản thân với người khác.', N''),
        (@b3, N'suggest', N'gợi ý, đề xuất', N'/səˈdʒest/', N'I suggest taking a short walk.', N'Tôi gợi ý đi dạo một chút.', N'Suggest đi với V-ing.'),
        (@b3, N'explain', N'giải thích', N'/ɪkˈspleɪn/', N'Can you explain this rule?', N'Bạn giải thích quy tắc này được không?', N''),
        (@b3, N'remember', N'nhớ', N'/rɪˈmembər/', N'I remember her name.', N'Tôi nhớ tên cô ấy.', N''),
        (@b3, N'forget', N'quên', N'/fəˈɡet/', N'Do not forget your keys.', N'Đừng quên chìa khóa.', N''),
        (@b3, N'decide', N'quyết định', N'/dɪˈsaɪd/', N'We decided to stay home.', N'Chúng tôi quyết định ở nhà.', N''),
        (@b3, N'prepare', N'chuẩn bị', N'/prɪˈpeər/', N'I need to prepare for the exam.', N'Tôi cần chuẩn bị cho kỳ thi.', N'Đi với for.'),
        (@b3, N'appreciate', N'trân trọng, biết ơn', N'/əˈpriːʃieɪt/', N'I appreciate your help.', N'Tôi biết ơn sự giúp đỡ của bạn.', N''),
        (@b3, N'familiar', N'quen thuộc', N'/fəˈmɪliər/', N'This song sounds familiar.', N'Bài hát này nghe quen quá.', N'Đi với with hoặc to.'),
        (@b3, N'efficient', N'hiệu quả', N'/ɪˈfɪʃnt/', N'This is an efficient way to study.', N'Đây là cách học hiệu quả.', N'');

    -- 10 từ Giáng sinh
    INSERT INTO Flashcards (FolderId, Word, Meaning, Example, ExampleTranslation) VALUES
        (@xmas, N'Christmas', N'lễ Giáng sinh', N'We decorate the tree at Christmas.', N'Chúng tôi trang trí cây thông vào Giáng sinh.'),
        (@xmas, N'gift', N'món quà', N'She gave me a lovely gift.', N'Cô ấy tặng tôi một món quà đáng yêu.'),
        (@xmas, N'snow', N'tuyết', N'It snows a lot in December.', N'Tháng Mười Hai tuyết rơi nhiều.'),
        (@xmas, N'decorate', N'trang trí', N'Let us decorate the house.', N'Hãy trang trí ngôi nhà nào.'),
        (@xmas, N'celebrate', N'ăn mừng', N'We celebrate with our family.', N'Chúng tôi ăn mừng cùng gia đình.'),
        (@xmas, N'reindeer', N'tuần lộc', N'Reindeer pull the sleigh.', N'Tuần lộc kéo chiếc xe trượt tuyết.'),
        (@xmas, N'stocking', N'tất treo quà', N'He hung a stocking by the fire.', N'Anh ấy treo một chiếc tất cạnh lò sưởi.'),
        (@xmas, N'carol', N'bài hát Giáng sinh', N'They sing a carol every year.', N'Họ hát một bài Giáng sinh mỗi năm.'),
        (@xmas, N'holiday', N'kỳ nghỉ lễ', N'The holiday starts tomorrow.', N'Kỳ nghỉ lễ bắt đầu từ ngày mai.'),
        (@xmas, N'tradition', N'truyền thống', N'This is an old family tradition.', N'Đây là một truyền thống lâu đời của gia đình.');

    -- 10 từ Tết
    INSERT INTO Flashcards (FolderId, Word, Meaning, Example, ExampleTranslation) VALUES
        (@tet, N'Lunar New Year', N'Tết Nguyên đán', N'Lunar New Year is in February.', N'Tết Nguyên đán vào tháng Hai.'),
        (@tet, N'lucky money', N'tiền lì xì', N'Children receive lucky money.', N'Trẻ em nhận tiền lì xì.'),
        (@tet, N'fireworks', N'pháo hoa', N'We watched the fireworks at midnight.', N'Chúng tôi xem pháo hoa lúc nửa đêm.'),
        (@tet, N'reunion', N'sum họp', N'The family reunion was wonderful.', N'Buổi sum họp gia đình thật tuyệt.'),
        (@tet, N'wish', N'lời chúc, mong ước', N'I wish you good health.', N'Tôi chúc bạn sức khỏe.'),
        (@tet, N'blessing', N'lời chúc phúc', N'Grandma gave us her blessing.', N'Bà đã chúc phúc cho chúng tôi.'),
        (@tet, N'spring', N'mùa xuân', N'Tet marks the start of spring.', N'Tết đánh dấu sự bắt đầu của mùa xuân.'),
        (@tet, N'ancestor', N'tổ tiên', N'We honor our ancestors.', N'Chúng tôi tưởng nhớ tổ tiên.'),
        (@tet, N'festival', N'lễ hội', N'The festival lasts for days.', N'Lễ hội kéo dài nhiều ngày.'),
        (@tet, N'prosperity', N'sự thịnh vượng', N'We wish you prosperity.', N'Chúng tôi chúc bạn thịnh vượng.');

    -- Thử thách ngày 24/12 và 25/12 dùng thư mục Giáng sinh
    INSERT INTO DailyChallenges (Day, FolderId) VALUES ('20261224', @xmas), ('20261225', @xmas);

    -- lan: bài 1 nhớ 9 từ (3 từ đầu mức Dễ, 6 từ mức Nhớ), từ thứ 10 mức Quên
    ;WITH L1 AS (SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) AS rn FROM Flashcards WHERE FolderId = @b1)
    INSERT INTO CardProgress (UserId, CardId, LastRating, WrongCount, LastWrongAnswer)
    SELECT @lan, Id,
           CASE WHEN rn <= 3 THEN 4 WHEN rn <= 9 THEN 3 ELSE 1 END,
           CASE WHEN rn = 10 THEN 2 ELSE 0 END,
           CASE WHEN rn = 10 THEN N'cải tiến' ELSE N'' END
    FROM L1;

    -- lan: 1 từ bài 2 mức Khó
    ;WITH L2 AS (SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) AS rn FROM Flashcards WHERE FolderId = @b2)
    INSERT INTO CardProgress (UserId, CardId, LastRating, WrongCount, LastWrongAnswer)
    SELECT @lan, Id, 2, 1, N'tự ti' FROM L2 WHERE rn = 1;

    -- minh: nhớ 5 từ bài 1
    ;WITH L1 AS (SELECT Id, ROW_NUMBER() OVER (ORDER BY Id) AS rn FROM Flashcards WHERE FolderId = @b1)
    INSERT INTO CardProgress (UserId, CardId, LastRating)
    SELECT @minh, Id, 3 FROM L1 WHERE rn <= 5;

    -- Ngày học: lan 6 ngày liên tiếp tới hôm qua, minh hôm qua và hôm kia
    INSERT INTO StudyDays (UserId, Day)
    SELECT @lan, DATEADD(DAY, -n, @today) FROM (VALUES (1), (2), (3), (4), (5), (6)) AS v(n);
    INSERT INTO StudyDays (UserId, Day)
    SELECT @minh, DATEADD(DAY, -n, @today) FROM (VALUES (1), (2)) AS v(n);

    -- Thử thách hôm qua
    INSERT INTO ChallengeResults (UserId, Day, Score, Total, Seconds) VALUES
        (@lan,  @yesterday, 8, 10, 125),
        (@minh, @yesterday, 9, 10, 140);

    -- Đua từ
    INSERT INTO RushResults (UserId, Score) VALUES (@lan, 14), (@lan, 19), (@minh, 21);
    """;
}
