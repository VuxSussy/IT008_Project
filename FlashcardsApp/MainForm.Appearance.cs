using System.ComponentModel;

namespace FlashcardsApp;

public partial class MainForm
{
    private int progressValue;
    private string exampleHighlight = "";
    private string wrongIcon = "info";

    private void InitializeRuntimeStyles()
    {
        StyleButton(overviewButton, "home", "", "", false);
        StyleButton(libraryButton, "cards", "", "", false);
        StyleButton(reviewButton, "review", "", "", false);
        StyleButton(mistakesButton, "book", "", "", false);
        StyleButton(statisticsButton, "stats", "", "", false);
        StyleButton(settingsButton, "settings", "", "", false);
        StyleButton(finishButton, "close", "", "", true);
        previousButton.Text = "";
        StyleButton(previousButton, "left", "", "", false);
        nextButton.Text = "";
        StyleButton(nextButton, "right", "", "", false);
        speakButton.Text = "";
        StyleButton(speakButton, "sound", "", "", true);
        StyleButton(flipButton, "book", "", "", false);
        againButton.Text = "Quên";
        StyleButton(againButton, "", "1 phút", "1", true);
        hardButton.Text = "Khó";
        StyleButton(hardButton, "", "10 phút", "2", true);
        goodButton.Text = "Nhớ";
        StyleButton(goodButton, "", "1 ngày", "3", true);
        easyButton.Text = "Dễ";
        StyleButton(easyButton, "", "4 ngày", "4", true);
        StyleButton(addButton, "plus", "", "", true);
        StyleButton(startReviewButton, "review", "", "", true);
        StyleButton(retryButton, "review", "", "", true);
        cardSurface.BorderStyle = mistakeSurface.BorderStyle = BorderStyle.None;
        cardSurface.Paint += (_, e) => NativeStudyPainting.Surface(cardSurface, e);
        mistakeSurface.Paint += (_, e) => NativeStudyPainting.Surface(mistakeSurface, e);
        savedLabel.Paint += (_, e) => NativeStudyPainting.Feedback(savedLabel, e, "dot");
        wrongLabel.Paint += (_, e) => NativeStudyPainting.Feedback(wrongLabel, e, wrongIcon);
        correctLabel.Paint += (_, e) => NativeStudyPainting.Feedback(correctLabel, e, "check");
        exampleLabel.Paint += (_, e) => NativeStudyPainting.Highlight(exampleLabel, e, exampleHighlight);
        progressTrack.Paint += (_, e) => NativeStudyPainting.Progress(progressTrack, e, progressValue);
    }

    private void StyleButton(Button button, string icon, string detail, string key, bool border)
    {
        var hovered = false;
        var pressed = false;
        button.Paint += (_, e) => NativeStudyPainting.Button(button, e, icon, detail, key,
            button.Tag is string page && page == currentPage, border, hovered, pressed);
        button.MouseEnter += (_, _) => { hovered = true; button.Invalidate(); };
        button.MouseLeave += (_, _) => { hovered = pressed = false; button.Invalidate(); };
        button.MouseDown += (_, _) => { pressed = true; button.Invalidate(); };
        button.MouseUp += (_, _) => { pressed = false; button.Invalidate(); };
        button.GotFocus += (_, _) => button.Invalidate();
        button.LostFocus += (_, _) => button.Invalidate();
    }
}
