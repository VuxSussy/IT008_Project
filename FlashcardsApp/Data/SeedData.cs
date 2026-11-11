namespace FlashcardsApp;

internal static class SeedData
{
    public const string CreateTable = @"
CREATE TABLE IF NOT EXISTS Flashcards (
    Id                 INTEGER PRIMARY KEY AUTOINCREMENT,
    Word               TEXT NOT NULL UNIQUE COLLATE NOCASE,
    Meaning            TEXT NOT NULL,
    Category           TEXT NOT NULL DEFAULT 'TỪ VỰNG',
    Pronunciation      TEXT NOT NULL DEFAULT '',
    Example            TEXT NOT NULL DEFAULT '',
    ExampleTranslation TEXT NOT NULL DEFAULT '',
    MemoryNote         TEXT NOT NULL DEFAULT '',
    CommonMistake      TEXT NOT NULL DEFAULT '',
    IsLearned          INTEGER NOT NULL DEFAULT 0,
    LastRating         INTEGER NOT NULL DEFAULT 0 CHECK (LastRating BETWEEN 0 AND 4),
    NextReviewAt       TEXT NULL
);";

    // Dán nguyên các dòng VALUES (...) từ script INSERT mình đưa trước đó vào đây.
    public const string InsertCards = @"
INSERT INTO Flashcards (Word, Meaning, Category, Pronunciation, Example, ExampleTranslation, MemoryNote, CommonMistake) VALUES
('make a decision','đưa ra quyết định','CỤM TỪ','/meɪk ə dɪˈsɪʒən/','I need to make a decision today.','Tôi cần đưa ra quyết định hôm nay.','Dùng make với decision.','do a decision'),
('take a break','nghỉ giải lao','CỤM TỪ','/teɪk ə breɪk/','Let us take a break for ten minutes.','Hãy nghỉ giải lao mười phút.','Dùng take với break.','make a break'),
('make progress','tiến bộ','CỤM TỪ','/meɪk ˈprəʊɡres/','You are making progress every week.','Bạn tiến bộ mỗi tuần.','Dùng make với progress.','do progress'),
('do homework','làm bài tập về nhà','CỤM TỪ','/duː ˈhəʊmwɜːk/','I do my homework after dinner.','Tôi làm bài tập sau bữa tối.','Dùng do với homework.','make homework'),
('pay attention to','chú ý đến','CỤM TỪ','/peɪ əˈtenʃn tuː/','Please pay attention to the teacher.','Hãy chú ý lắng nghe giáo viên.','Đi với giới từ to.',''),
('look forward to','mong đợi','CỤM TỪ','/lʊk ˈfɔːwəd tuː/','I look forward to meeting you.','Tôi mong được gặp bạn.','To ở đây + V-ing.',''),
('give up','từ bỏ','CỤM TỪ','/ɡɪv ʌp/','Never give up on your goals.','Đừng bao giờ từ bỏ mục tiêu.','',''),
('depend on','phụ thuộc vào','CỤM TỪ','/dɪˈpend ɒn/','It depends on the weather.','Điều đó phụ thuộc vào thời tiết.','Đi với giới từ on.','depend of'),
('curious','tò mò, ham tìm hiểu','TỪ VỰNG','/ˈkjʊəriəs/','She is curious about the world.','Cô ấy tò mò về thế giới.','',''),
('improve','cải thiện','TỪ VỰNG','/ɪmˈpruːv/','I practice every day to improve my English.','Tôi luyện tập mỗi ngày để cải thiện tiếng Anh.','',''),
('confident','tự tin','TỪ VỰNG','/ˈkɒnfɪdənt/','He feels confident when speaking English.','Anh ấy cảm thấy tự tin khi nói tiếng Anh.','',''),
('achieve','đạt được','TỪ VỰNG','/əˈtʃiːv/','Small steps help you achieve your goals.','Những bước nhỏ giúp bạn đạt được mục tiêu.','',''),
('borrow','mượn (từ ai đó)','TỪ VỰNG','/ˈbɒrəʊ/','Can I borrow your pen?','Tôi mượn bút của bạn được không?','Borrow = nhận, lend = đưa.','lend (nhầm nghĩa)'),
('lend','cho mượn','TỪ VỰNG','/lend/','Can you lend me some money?','Bạn cho tôi mượn ít tiền được không?','',''),
('knowledge','kiến thức','TỪ VỰNG','/ˈnɒlɪdʒ/','Reading gives you a lot of knowledge.','Đọc sách mang lại nhiều kiến thức.','Danh từ không đếm được.','knowledges'),
('environment','môi trường','TỪ VỰNG','/ɪnˈvaɪrənmənt/','We must protect the environment.','Chúng ta phải bảo vệ môi trường.','',''),
('experience','kinh nghiệm, trải nghiệm','TỪ VỰNG','/ɪkˈspɪəriəns/','She has five years of experience.','Cô ấy có năm năm kinh nghiệm.','',''),
('opportunity','cơ hội','TỪ VỰNG','/ˌɒpəˈtjuːnəti/','This job is a great opportunity.','Công việc này là cơ hội tuyệt vời.','',''),
('responsible','chịu trách nhiệm','TỪ VỰNG','/rɪˈspɒnsəbl/','He is responsible for the project.','Anh ấy chịu trách nhiệm cho dự án.','Đi với for.',''),
('available','có sẵn, rảnh','TỪ VỰNG','/əˈveɪləbl/','Are you available tomorrow?','Ngày mai bạn có rảnh không?','',''),
('compare','so sánh','TỪ VỰNG','/kəmˈpeər/','Do not compare yourself with others.','Đừng so sánh bản thân với người khác.','',''),
('suggest','gợi ý, đề xuất','TỪ VỰNG','/səˈdʒest/','I suggest taking a short walk.','Tôi gợi ý đi dạo một chút.','Suggest + V-ing.','suggest to go'),
('explain','giải thích','TỪ VỰNG','/ɪkˈspleɪn/','Can you explain this rule?','Bạn giải thích quy tắc này được không?','',''),
('remember','nhớ','TỪ VỰNG','/rɪˈmembər/','I remember her name.','Tôi nhớ tên cô ấy.','',''),
('forget','quên','TỪ VỰNG','/fəˈɡet/','Do not forget your keys.','Đừng quên chìa khóa.','',''),
('decide','quyết định','TỪ VỰNG','/dɪˈsaɪd/','We decided to stay home.','Chúng tôi quyết định ở nhà.','',''),
('prepare','chuẩn bị','TỪ VỰNG','/prɪˈpeər/','I need to prepare for the exam.','Tôi cần chuẩn bị cho kỳ thi.','Đi với for.',''),
('appreciate','trân trọng, biết ơn','TỪ VỰNG','/əˈpriːʃieɪt/','I appreciate your help.','Tôi biết ơn sự giúp đỡ của bạn.','',''),
('familiar','quen thuộc','TỪ VỰNG','/fəˈmɪliər/','This song sounds familiar.','Bài hát này nghe quen quá.','Đi với with / to.',''),
('efficient','hiệu quả','TỪ VỰNG','/ɪˈfɪʃnt/','This is an efficient way to study.','Đây là cách học hiệu quả.','','');
;";
}
