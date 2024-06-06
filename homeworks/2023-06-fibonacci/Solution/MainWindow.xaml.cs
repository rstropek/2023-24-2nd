using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Fibonacci;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int GamePoints = 0;
    private int GameLives = 3;
    private bool GameOver = false;

    public MainWindow()
    {
        InitializeComponent();
        UpdateTexts();
        ValueInput.Focus();
    }

    private void OnCheck(object sender, RoutedEventArgs e)
    {
        var n = TopLevelPanel.Children.Count;
        var expected = GetNthFibonacci(n - 1);
        if (int.TryParse(ValueInput.Text, out var valueInput) && expected == valueInput)
        {
            GamePoints += (int)Math.Pow(GetNumberOfDigits(expected), 2);

            var stackPanel = new StackPanel { Orientation = Orientation.Horizontal };
            stackPanel.Children.Add(new TextBox { IsReadOnly = true, Text = valueInput.ToString() });
            stackPanel.Children.Add(new TextBlock());
            TopLevelPanel.Children.Insert(n - 1, stackPanel);
            ValueInput.Text = "";

            ValueInput.Background = Brushes.White;
            ValueInput.Foreground = Brushes.Black;
            ValueInput.BorderBrush = Brushes.Black;

        }
        else
        {
            ValueInput.Background = Brushes.Red;
            ValueInput.Foreground = Brushes.White;
            ValueInput.BorderBrush = Brushes.DarkRed;
            ValueInput.SelectAll();
            GameLives--;
            if (GameLives == 0)
            {
                GameOver = true;
                GameDock.Visibility = Visibility.Hidden;
                GameOverPanel.Visibility = Visibility.Visible;
                GameOverText.Text= $"You scored {GamePoints} points!";
            }
        }

        UpdateTexts();
    }

    private static long GetNthFibonacci(int n)
    {
        if (n == 0) {  return 0; }
        if (n == 1) { return 1; }
        return GetNthFibonacci(n - 1) + GetNthFibonacci(n - 2);
    }

    private static int GetNumberOfDigits(long value)
    {
        if (value == 0) { return 1; }
        return (int)Math.Floor(Math.Log10(Math.Abs(value)) + 1);
    }

    private void OnRestart(object sender, RoutedEventArgs e)
    {
        while (TopLevelPanel.Children.Count > 3)
        {
            TopLevelPanel.Children.RemoveAt(2);
        }

        ValueInput.Background = Brushes.White;
        ValueInput.Foreground = Brushes.Black;
        ValueInput.BorderBrush = Brushes.Black;
        GameDock.Visibility = Visibility.Visible;
        GameOverPanel.Visibility = Visibility.Hidden;

        GameOver = false;
        GamePoints = 0;
        GameLives = 3;
        UpdateTexts();

        ValueInput.Text = "";
        ValueInput.Focus();
    }

    private void UpdateTexts()
    {
        Points.Text = $"{GamePoints} Points";
        var livesBuilder = new StringBuilder();
        for (var i = 0; i < GameLives; i++)
        {
            livesBuilder.Append("💗");
        }
        
        Lives.Text = livesBuilder.ToString();
    }
}