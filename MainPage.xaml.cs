namespace MauiApp1;

public partial class MainPage : ContentPage
{
    int count = 0;
    IDispatcherTimer dispatcherTimer = null;
    int tenthsOfSecondsElapsed;
    int matchesFound;

    Button lastButtonClicked;
    bool findingMatch = false;

    public MainPage()
    {
        InitializeComponent();
        dispatcherTimer.Interval = TimeSpan.FromSeconds(.1);
        dispatcherTimer.Tick += dispatcherTimer_Tick;

        SetUpGame();
    }

    private void dispatcherTimer_Tick(object? sender, EventArgs e)
    {
        tenthsOfSecondsElapsed++;
        timeDisplay.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
        if (matchesFound == 8)
        {
            dispatcherTimer.Stop();
            timeDisplay.Text = "Parabéns!";
        }
    }

    private void SetUpGame()
    {
        List<string> animalEmoji = new List<string>()
        {
                "🐶","🐶",
                "🐮","🐮",
                "🦊","🦊",
                "🐭","🐭",
                "🐷","🐷",
                "🐰","🐰",
                "🐵","🐵",
                "🐸","🐸"
        };
        Random random = new Random();
        foreach (Button button in mainGrid.Children.OfType<Button>())
        {
            if (button.Text != "timeTextBlock")
            {
                button.IsVisible = true;
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                button.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        }

        dispatcherTimer.Start();
        tenthsOfSecondsElapsed = 0;
        matchesFound = 0;
    }

    private void OnButtonPressed(object sender, EventArgs e)
    {
        dispatcherTimer.Stop();
    }
}

