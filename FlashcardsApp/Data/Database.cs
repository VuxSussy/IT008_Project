using Microsoft.Data.SqlClient;
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

    // 3 tài khoản mẫu, mật khẩu đều là 123456:
    //   Id 1 admin (Admin), Id 2 lan (User), Id 3 minh (User)
    // Mã hóa bằng HASHBYTES cho khớp với UserStore.HashPassword
    const string SampleDataSql = """
        INSERT INTO Users (Username, PasswordHash, Role) VALUES
            ('admin', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin:123456'), 2), 'Admin'),
            ('lan',   CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'lan:123456'),   2), 'User'),
            ('minh',  CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'minh:123456'),  2), 'User');

        -- Mỗi người một thư mục "Chưa phân loại"
        INSERT INTO Folders (Name, OwnerId, IsDefault) VALUES
            (N'Chưa phân loại', 1, 1), (N'Chưa phân loại', 2, 1), (N'Chưa phân loại', 3, 1);

        -- Khóa học mẫu: 3 bài là 3 thư mục của admin (Id 4, 5, 6)
        INSERT INTO Courses (Title, Description) VALUES (N'Tiếng Anh giao tiếp', N'Từ vựng hằng ngày');
        INSERT INTO Folders (Name, OwnerId, CourseId, LessonOrder) VALUES
            (N'Bài 1 · Daily life', 1, 1, 1),
            (N'Bài 2 · At work',    1, 1, 2),
            (N'Bài 3 · Travel',     1, 1, 3);

        INSERT INTO Flashcards (FolderId, Word, Meaning, Pronunciation, Example, ExampleTranslation) VALUES
            (4, N'curious', N'tò mò', N'/ˈkjʊəriəs/', N'She is curious about everything.', N'Cô ấy tò mò về mọi thứ.'),
            (4, N'commute', N'đi làm hằng ngày', N'/kəˈmjuːt/', N'', N'');
            -- ... thêm cho đủ 30 từ, mỗi bài 10 từ
        """;
}
