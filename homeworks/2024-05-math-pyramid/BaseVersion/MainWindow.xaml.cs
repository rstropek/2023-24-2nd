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
            // The input is valid, generate the pyramid
            GeneratePyramid(numberOfDigitsInBase, widthOfBase);
        }
        else
        {
            MessageBox.Show("Number of digits in base must be between 1 and 3, width of base must be between 2 and 10.");
        }
    }

    private void GeneratePyramid(int numberOfDigitsInBase, int widthOfBase)
    {
        // NOTE: Focus handling is optional. This will not be part of any exam.

        // Reset everything (clear the pyramid, reset the background color, clear the inputs list)
        Pyramid.Children.Clear();
        Pyramid.Background = Brushes.White;
        inputs.Clear();

        // We manually set the tab index so that the user can navigate the pyramid
        // from bottom to top using the tab key.
        var tabIndex = 0;
        for (var currentWidth = widthOfBase; currentWidth >= 1; currentWidth--)
        {
            // Create the stack panel and the list of text boxes for the current line
            var linePanel = new StackPanel() { Orientation = Orientation.Horizontal };
            var lineInputs = new List<TextBox>();

            // Create the text boxes for the current line
            for (var i = 0; i < currentWidth; i++)
            {
                var textBox = new TextBox();
                if (currentWidth == widthOfBase)
                {
                    // The text boxes at the base of the pyramid are read-only and not focusable.
                    // We fill them with random numbers.
                    textBox.Text = Random.Shared.Next((int)Math.Pow(10, numberOfDigitsInBase)).ToString();
                    textBox.IsReadOnly = true;
                    textBox.Focusable = false;
                }
                else
                {
                    // The text boxes in the rest of the pyramid are focusable and editable.
                    KeyboardNavigation.SetTabIndex(textBox, tabIndex++);
                }

                // Add the text box to the stack panel and to the list of text boxes
                linePanel.Children.Add(textBox);
                lineInputs.Add(textBox);
            }

            // Add the stack panel to the pyramid and the list of text boxes to the inputs list.
            // We need to insert at the beginning of the list because we build the pyramid 
            // starting with the bottom line and adding lines on top of it.
            Pyramid.Children.Insert(0, linePanel);
            inputs.Insert(0, lineInputs);
        }

        // Focus the first input (ignore the first line because it's read-only)
        inputs[^2][0].Focus();
    }

    private void OnCheck(object sender, RoutedEventArgs e)
    {
        var correct = true;
        Pyramid.Background = Brushes.White;

        // Iterate over the editable lines of the pyramid.
        for (var row = inputs.Count - 2; row >= 0; row--)
        {
            var lineInput = inputs[row];
            for (var col = 0; col < lineInput.Count; col++)
            {
                // Validate the input
                if (int.TryParse(lineInput[col].Text, out var inputValue)
                    && int.TryParse(inputs[row + 1][col].Text, out var belowLeftValue)
                    && int.TryParse(inputs[row + 1][col + 1].Text, out var belowRightValue)
                    && inputValue == belowLeftValue + belowRightValue)
                {
                    // Input is correct
                    lineInput[col].Background = Brushes.White;
                    lineInput[col].Foreground = Brushes.Black;
                }
                else
                {
                    // Input is incorrect
                    lineInput[col].Background = Brushes.Red;
                    lineInput[col].Foreground = Brushes.White;
                    correct = false;
                }
            }
        }

        if (correct) { Pyramid.Background = Brushes.Lime; }
    }
}