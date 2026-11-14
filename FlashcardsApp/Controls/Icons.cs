using System.Drawing.Drawing2D;

namespace FlashcardsApp;

// Vẽ biểu tượng bằng nét bút, không cần file ảnh.
// Mỗi biểu tượng được vẽ trên một ô 24×24, rồi phóng to hay thu nhỏ cho vừa chỗ cần vẽ.
// Thêm biểu tượng mới: thêm một "case" với tên mới, vẽ trong ô 24×24.
internal static class Icons
{
    public static void Draw(Graphics g, string name, Rectangle bounds, Color color)
    {
        if (string.IsNullOrEmpty(name)) return;

        // Dời gốc tọa độ tới góc ô cần vẽ và co giãn để ô 24×24 vừa bằng ô đó
        var savedState = g.Save();
        g.TranslateTransform(bounds.X, bounds.Y);
        g.ScaleTransform(bounds.Width / 24f, bounds.Height / 24f);

        using var pen = new Pen(color, 1.7f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };
        using var brush = new SolidBrush(color);

        switch (name)
        {
            case "home": // ngôi nhà
                g.DrawLines(pen, new PointF[] { new(3, 10), new(12, 3), new(21, 10) });
                g.DrawLines(pen, new PointF[] { new(5, 9), new(5, 21), new(10, 21), new(10, 14), new(15, 14), new(15, 21), new(20, 21), new(20, 9) });
                break;

            case "cards": // hai thẻ chồng lên nhau
                g.DrawRectangle(pen, 5, 6, 13, 16);
                g.DrawLines(pen, new PointF[] { new(8, 3), new(21, 5), new(21, 19) });
                break;

            case "review": // mũi tên quay vòng
                g.DrawArc(pen, 4, 4, 16, 16, 35, 290);
                g.DrawLines(pen, new PointF[] { new(20, 3), new(20, 9), new(14, 9) });
                break;

            case "book": // cuốn sổ
                g.DrawRectangle(pen, 6, 3, 15, 18);
                for (var y = 7; y < 20; y += 4)
                {
                    g.DrawLine(pen, 3, y, 8, y);
                }
                g.DrawLine(pen, 11, 8, 17, 8);
                g.DrawLine(pen, 11, 12, 17, 12);
                break;

            case "stats": // biểu đồ cột
                g.FillRectangle(brush, 4, 14, 4, 8);
                g.FillRectangle(brush, 10, 4, 4, 18);
                g.FillRectangle(brush, 16, 9, 4, 13);
                break;

            case "sound": // loa
                g.DrawPolygon(pen, new PointF[] { new(3, 9), new(7, 9), new(12, 5), new(12, 19), new(7, 15), new(3, 15) });
                g.DrawArc(pen, 10, 7, 8, 10, -60, 120);
                g.DrawArc(pen, 10, 3, 13, 18, -60, 120);
                break;

            case "close": // dấu X
                g.DrawLine(pen, 6, 6, 18, 18);
                g.DrawLine(pen, 18, 6, 6, 18);
                break;

            case "plus": // dấu cộng
                g.DrawLine(pen, 12, 5, 12, 19);
                g.DrawLine(pen, 5, 12, 19, 12);
                break;

            case "check": // vòng tròn có dấu tích (đúng)
                g.DrawEllipse(pen, 3, 3, 18, 18);
                g.DrawLines(pen, new PointF[] { new(7, 12), new(10, 15), new(17, 8) });
                break;

            case "wrong": // vòng tròn có dấu X (sai)
                g.DrawEllipse(pen, 3, 3, 18, 18);
                g.DrawLine(pen, 8, 8, 16, 16);
                g.DrawLine(pen, 16, 8, 8, 16);
                break;

            case "settings": // bánh răng: 2 vòng tròn và 8 răng xung quanh
                g.DrawEllipse(pen, 5, 5, 14, 14);
                g.DrawEllipse(pen, 9, 9, 6, 6);
                for (var i = 0; i < 8; i++)
                {
                    var angle = i * Math.PI / 4;
                    var cos = (float)Math.Cos(angle);
                    var sin = (float)Math.Sin(angle);
                    g.DrawLine(pen, 12 + cos * 8, 12 + sin * 8, 12 + cos * 10, 12 + sin * 10);
                }
                break;

            case "info": // vòng tròn có chữ i
                g.DrawEllipse(pen, 3, 3, 18, 18);
                g.DrawLine(pen, 12, 11, 12, 17);
                g.FillEllipse(brush, 11, 6, 2, 2);
                break;

            case "left": // mũi tên sang trái
                g.DrawLines(pen, new PointF[] { new(15, 5), new(8, 12), new(15, 19) });
                break;

            case "right": // mũi tên sang phải
                g.DrawLines(pen, new PointF[] { new(9, 5), new(16, 12), new(9, 19) });
                break;

            case "dot": // chấm tròn
                g.FillEllipse(brush, 8, 8, 8, 8);
                break;

            case "folder": // thư mục
                g.DrawLines(pen, new PointF[] { new(3, 19), new(3, 5), new(9, 5), new(11, 8), new(21, 8), new(21, 19), new(3, 19) });
                break;

            case "keyboard": // bàn phím
                g.DrawRectangle(pen, 2, 6, 20, 13);
                for (var x = 6; x <= 18; x += 4)
                {
                    g.DrawLine(pen, x, 10, x + .5f, 10);
                    g.DrawLine(pen, x, 13, x + .5f, 13);
                }
                g.DrawLine(pen, 8, 16, 16, 16);
                break;

            case "match": // 4 ô vuông
                g.DrawRectangle(pen, 3, 3, 7, 7);
                g.DrawRectangle(pen, 14, 3, 7, 7);
                g.DrawRectangle(pen, 3, 14, 7, 7);
                g.DrawRectangle(pen, 14, 14, 7, 7);
                break;

            case "course": // cuốn sách có gáy
                g.DrawLines(pen, new PointF[] { new(4, 19), new(4, 5), new(6, 3), new(20, 3), new(20, 17), new(6.5f, 17), new(4, 19) });
                g.DrawLines(pen, new PointF[] { new(4, 19), new(6.5f, 21), new(20, 21), new(20, 17) });
                break;

            case "challenge": // tờ lịch có dấu tích
                g.DrawRectangle(pen, 4, 5, 16, 16);
                g.DrawLine(pen, 4, 9, 20, 9);
                g.DrawLine(pen, 8, 3, 8, 7);
                g.DrawLine(pen, 16, 3, 16, 7);
                g.DrawLines(pen, new PointF[] { new(9, 15), new(11, 17), new(15, 13) });
                break;

            case "rush": // tia chớp
                g.DrawPolygon(pen, new PointF[] { new(13, 2), new(4, 14), new(11, 14), new(10, 22), new(19, 10), new(12, 10) });
                break;

            case "trophy": // cúp
                g.DrawLines(pen, new PointF[] { new(7, 9), new(7, 4), new(17, 4), new(17, 9) });
                g.DrawArc(pen, 7, 4, 10, 10, 0, 180);
                g.DrawLine(pen, 12, 14, 12, 20);
                g.DrawLine(pen, 8, 21, 16, 21);
                g.DrawLines(pen, new PointF[] { new(17, 5), new(20, 5), new(20, 7), new(17, 10) });
                g.DrawLines(pen, new PointF[] { new(7, 5), new(4, 5), new(4, 7), new(7, 10) });
                break;

            case "admin": // tấm khiên có dấu tích
                g.DrawPolygon(pen, new PointF[] { new(12, 3), new(4, 6), new(4, 12), new(6, 17), new(12, 21), new(18, 17), new(20, 12), new(20, 6) });
                g.DrawLines(pen, new PointF[] { new(9, 12), new(11, 14), new(15, 10) });
                break;

            case "logout": // cửa và mũi tên đi ra
                g.DrawLines(pen, new PointF[] { new(9, 21), new(4, 21), new(3, 20), new(3, 4), new(4, 3), new(9, 3) });
                g.DrawLines(pen, new PointF[] { new(16, 7), new(21, 12), new(16, 17) });
                g.DrawLine(pen, 21, 12, 9, 12);
                break;

            case "user": // người
                g.DrawEllipse(pen, 8, 4, 8, 8);
                g.DrawArc(pen, 4, 14, 16, 14, 180, 180);
                break;

            case "gift": // hộp quà
                g.DrawRectangle(pen, 3, 9, 18, 4);
                g.DrawRectangle(pen, 5, 13, 14, 8);
                g.DrawLine(pen, 12, 9, 12, 21);
                g.DrawEllipse(pen, 7.5f, 4.5f, 4.5f, 4.5f);
                g.DrawEllipse(pen, 12, 4.5f, 4.5f, 4.5f);
                break;

            case "flame": // ngọn lửa, tô kín
                g.FillClosedCurve(brush, new PointF[] { new(12, 22), new(6.5f, 19), new(5.5f, 14), new(8, 8.5f), new(11, 2), new(13.5f, 7.5f), new(15.5f, 7), new(18.5f, 13), new(17.5f, 19) }, FillMode.Alternate, .5f);
                break;

            case "star": // ngôi sao, tô kín
                g.FillPolygon(brush, new PointF[] { new(12, 3), new(14.7f, 8.6f), new(20.8f, 9.5f), new(16.4f, 13.8f), new(17.4f, 19.9f), new(12, 17), new(6.6f, 19.9f), new(7.6f, 13.8f), new(3.2f, 9.5f), new(9.3f, 8.6f) });
                break;
        }

        g.Restore(savedState);
    }
}
