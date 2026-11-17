using Microsoft.Data.SqlClient;

namespace FlashcardsApp;

// Tạo file dữ liệu flashcards.db, tạo 2 bảng và 30 từ mẫu. Việc của #4, xem docs/03-database.md.
// Các chỗ ghi "TODO (#4)" là phần còn phải viết. Trong Visual Studio mở View → Task List để thấy hết.
public static class Database
{
    // File dữ liệu nằm cạnh file chạy của app: FlashcardsApp/bin/Debug/net10.0-windows/flashcards.db
    // Mọi lớp ...Store dùng chuỗi này để mở kết nối:
    //     using var conn = new SqliteConnection(Database.ConnectionString);
    // Foreign Keys=True: không cho gán từ vào thư mục không tồn tại
    public static string ConnectionString =>
        Environment.GetEnvironmentVariable("FLASHCARDS_DB")
        ?? @"Server=localhost\SQLEXPRESS;Database=FlashcardsDb;Trusted_Connection=True;TrustServerCertificate=True";
    // Program.cs gọi hàm này một lần, trước khi mở cửa sổ chính.
    // Đã có file thì thôi; chưa có thì tạo bảng và thêm dữ liệu mẫu.
    public static void EnsureCreated()
    {
        // Bước 1: nối vào master, chưa có FlashcardsDb thì tạo
        var builder = new SqlConnectionStringBuilder(ConnectionString);
        var dbName = builder.InitialCatalog;      // "FlashcardsDb"
        builder.InitialCatalog = "master";

        using (var master = new SqlConnection(builder.ConnectionString))
        {
            master.Open();
            using var cmd = master.CreateCommand();
            cmd.CommandText = @"
            IF DB_ID(@db) IS NULL
            BEGIN
                DECLARE @sql NVARCHAR(MAX) =
                    N'CREATE DATABASE ' + QUOTENAME(@db) + N' COLLATE Vietnamese_CI_AS';
                EXEC(@sql);
            END";
            cmd.Parameters.AddWithValue("@db", dbName);
            cmd.ExecuteNonQuery();
        }

        // Bước 2: nối vào FlashcardsDb, chưa có bảng Users thì tạo bảng + dữ liệu mẫu
        using var conn = new SqlConnection(ConnectionString);
        conn.Open();

        using (var check = conn.CreateCommand())
        {
            check.CommandText = "SELECT OBJECT_ID(N'dbo.Users', N'U')";
            var exists = check.ExecuteScalar();
            if (exists is not null && exists is not DBNull) return;   // đã có rồi thì thôi
        }

        using var tx = conn.BeginTransaction();
        using (var create = conn.CreateCommand())
        {
            create.Transaction = tx;
            create.CommandText = CreateTablesSql;
            create.ExecuteNonQuery();
        }
        using (var seed = conn.CreateCommand())
        {
            seed.Transaction = tx;
            seed.CommandText = SampleDataSql;
            seed.ExecuteNonQuery();
        }
        tx.Commit();
    }

    // Câu lệnh tạo 2 bảng, đúng theo docs/03. Muốn đổi cột thì sửa docs/03 trước, rồi báo cả nhóm.
    // Chuỗi nhiều dòng viết giữa hai dấu """
    private const string CreateTablesSql = """
        CREATE TABLE Folders (
            Id    INTEGER PRIMARY KEY AUTOINCREMENT,  -- máy tự đánh số 1, 2, 3...
            Name  TEXT NOT NULL UNIQUE                -- bắt buộc, không trùng
        );

        CREATE TABLE Flashcards (
            Id                  INTEGER PRIMARY KEY AUTOINCREMENT,
            FolderId            INTEGER NOT NULL DEFAULT 1 REFERENCES Folders(Id),
            Word                TEXT NOT NULL,
            Meaning             TEXT NOT NULL,
            Pronunciation       TEXT NOT NULL DEFAULT '',  -- '' = để trống
            Example             TEXT NOT NULL DEFAULT '',
            ExampleTranslation  TEXT NOT NULL DEFAULT '',
            MemoryNote          TEXT NOT NULL DEFAULT '',
            LastRating          INTEGER NOT NULL DEFAULT 0,
            WrongCount          INTEGER NOT NULL DEFAULT 0,
            LastWrongAnswer     TEXT NOT NULL DEFAULT ''
        );

        INSERT INTO Folders (Name) VALUES ('Chưa phân loại');
        """;

    // 3 thư mục mẫu (số 2, 3, 4) và 30 từ mẫu
    // TODO (#4): điền đủ 30 từ, lấy từ file JSON của bản chạy thử. Nhớ:
    //   - chữ có dấu nháy gõ 2 lần: 'don''t'
    //   - cột không có thì ghi '' (chuỗi rỗng), không ghi NULL
    //   - dòng cuối kết thúc bằng dấu chấm phẩy, các dòng trước bằng dấu phẩy
    private const string SampleDataSql = """
        INSERT INTO Folders (Name) VALUES ('Thư mục mẫu 1'), ('Thư mục mẫu 2'), ('Thư mục mẫu 3');

        INSERT INTO Flashcards (FolderId, Word, Meaning, Pronunciation, Example, ExampleTranslation) VALUES
            (2, 'curious', 'tò mò', '/ˈkjʊəriəs/', 'She is curious about everything.', 'Cô ấy tò mò về mọi thứ.'),
            (2, 'commute', 'đi làm hằng ngày', '/kəˈmjuːt/', '', '');
        """;
}
