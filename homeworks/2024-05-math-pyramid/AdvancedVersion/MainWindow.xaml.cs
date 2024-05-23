using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MathPyramid;

public partial class MainWindow : Window
{
    /// <summary>
    /// Helper list to store the TextBoxes in the pyramid.
    /// </summary>
    /// <remarks>
    /// Putting all text boxes in this list makes it easier to access them.
    /// We did the same trick in previous WPF examples.
    /// </remarks>
    private readonly List<List<TextBox>> inputs = [];

    /// <summary>
    /// Helper list to store the operators in the pyramid.
    /// </summary>
    private readonly List<List<TextBlock>> operators = [];

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnStart(object sender, RoutedEventArgs e)
    {
        // Validate the input
        if (int.TryParse(NumberOfDigitsInBase.Text, out var numberOfDigitsInBase)
            && int.TryParse(WidthOfBase.Text, out var widthOfBase)
            && numberOfDigitsInBase is >= 1 and <= 3
            && widthOfBase is >= 2 and <= 10)
        {
            GeneratePyramid(numberOfDigitsInBase, widthOfBase);
        }
        else
        {
            MessageBox.Show("Number of digits in base must be between 1 and 3, width of base must be between 2 and 10.");
        }
    }

    private void GeneratePyramid(int numberOfDigitsInBase, int widthOfBase)
    {
        Pyramid.Children.Clear();
        Pyramid.Background = Brushes.White;
        inputs.Clear();
        operators.Clear();
        var tabIndex = 0;
        for (var currentWidth = widthOfBase; currentWidth >= 1; currentWidth--)
        {
            var line = new StackPanel() { Orientation = Orientation.Horizontal };
            var lineInputs = new List<TextBox>();
            var lineOperatorsPanel = new StackPanel() { Orientation = Orientation.Horizontal };
            var lineOperators = new List<TextBlock>();
            for (var i = 0; i < currentWidth; i++)
            {
                var textBox = new TextBox();
                if (currentWidth == widthOfBase)
                {
                    textBox.Text = Random.Shared.Next((int)Math.Pow(10, numberOfDigitsInBase)).ToString();
                    textBox.IsReadOnly = true;
                    textBox.Focusable = false;
                }
                else
                {
                    KeyboardNavigation.SetTabIndex(textBox, tabIndex++);
                }

                if (currentWidth != widthOfBase)
                {
                    var operatorsText = new TextBlock() { Text = Random.Shared.Next(2) < 1 ? "+" : "-", };
                    lineOperators.Add(operatorsText);
                    lineOperatorsPanel.Children.Add(operatorsText);
                }

                line.Children.Add(textBox);
                lineInputs.Add(textBox);
            }

            if (currentWidth != widthOfBase) { Pyramid.Children.Insert(0, lineOperatorsPanel); }

            Pyramid.Children.Insert(0, line);
            inputs.Insert(0, lineInputs);
            operators.Insert(0, lineOperators);
        }

        inputs[^2][0].Focus();
    }

    private void OnCheck(object sender, RoutedEventArgs e)
    {
        var correct = true;
        Pyramid.Background = Brushes.White;
        for (var row = inputs.Count - 2; row >= 0; row--)
        {
            var lineInput = inputs[row];
            for (var col = 0; col < lineInput.Count; col++)
            {
                var op = operators[row][col].Text;
                if (!(int.TryParse(lineInput[col].Text, out var inputValue)
                    && int.TryParse(inputs[row + 1][col].Text, out var belowLeftValue)
                    && int.TryParse(inputs[row + 1][col + 1].Text, out var belowRightValue)
                    && inputValue == belowLeftValue + belowRightValue * (op == "-" ? -1 : 1)))
                {
                    lineInput[col].Background = Brushes.Red;
                    lineInput[col].Foreground = Brushes.White;
                    correct = false;
                }
                else
                {
                    lineInput[col].Background = Brushes.White;
                    lineInput[col].Foreground = Brushes.Black;
                }
            }
        }

        if (correct)
        {
            Pyramid.Background = Brushes.Lime;
        }
    }
}