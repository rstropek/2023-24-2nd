using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace TicTacToe;

/*
This class implements a simple game of Tic Tac Toe in WPF.

Here's a high-level overview of how this class works:

1. Properties: The class has two private properties.
   CurrentPlayer keeps track of whose turn it is ('X' or 'O'). 
   Borders is a 2D array of Border controls that contain the TextBlocks.
   TextBlocks is a 2D array that represents the Tic Tac Toe board.
   Each cell in the board is a TextBlock control that can display text ('X', 'O', or empty).

2. Constructor and Event Handlers: In the constructor, it initializes the 
   component and attaches an event handler OnLoaded to the Loaded event. 
   This event handler is invoked when the WPF application has been loaded and 
   is about to be rendered. In OnLoaded, it initializes the game board and the 
   combo boxes for selecting rows and columns.

3. Game Logic: The OnSet method is attached to a button click event (see XAML). When the 
   button is clicked, it checks if the selected cell is empty. If it is, it sets the cell 
   to the current player's symbol and switches the turn to the other player. 
   It then checks if there's a winner with the GetWinner method. If there's a winner, 
   it replaces the row/column selection with a winning message.

4. Winning Condition Check: The GetWinner method checks the winning conditions of a 
   Tic Tac Toe game. It checks all rows, columns, and diagonals to see if all cells 
   in a line are filled with the same player's symbol. If a winning condition is met, 
   it returns the symbol of the winner.
*/

public partial class MainWindow : Window
{
    private char CurrentPlayer { get; set; } = 'X';

    private Border[,] Borders { get; } = new Border[3, 3];

    private TextBlock[,] TextBlocks { get; } = new TextBlock[3, 3];

    public MainWindow()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        // Add values 1..3 to both combo boxes.
        // NOTE that the values in the combo boxes are INTEGER VALUES.
        // Combo boxes in WPF allow that. 
        for (var i = 0; i < 3; i++)
        {
            RowCombo.Items.Add(i + 1);
            ColumnCombo.Items.Add(i + 1);
        }

        // Set the default values for the combo boxes.
        RowCombo.SelectedItem = 1;
        ColumnCombo.SelectedItem = 1;

        // Initialize the game board.
        var rowsPanel = new StackPanel();
        for (int i = 0; i < 3; i++)
        {
            var row = new StackPanel { Orientation = Orientation.Horizontal };
            for (int j = 0; j < 3; j++)
            {
                TextBlocks[i, j] = new()
                {
                    FontSize = 24,
                    FontFamily = new FontFamily("Arial Black"),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };
                var cell = new Border
                {
                    Width = 50,
                    Height = 50,
                    Child = TextBlocks[i, j],
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Margin = new Thickness(1),
                };
                Borders[i, j] = cell;
                row.Children.Add(cell);
            }
            rowsPanel.Children.Add(row);
        }

        Panel.Children.Add(rowsPanel);
    }

    private void OnSet(object sender, RoutedEventArgs e)
    {
        // Ensure that the selected row and column are valid and the cell is empty.
        if (RowCombo.SelectedValue is int row
            && ColumnCombo.SelectedValue is int column
            && TextBlocks[row - 1, column - 1].Text == "")
        {
            // Set the cell to the current player's symbol.
            TextBlocks[row - 1, column - 1].Text = CurrentPlayer.ToString();

            // Switch the turn to the other player.
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';

            // Check if there's a winner.
            char winner = GetWinner();
            if (winner != ' ')
            {
                // Display the winning message by replacing the row/column selection.
                NextMove.Children.Clear();
                NextMove.Children.Add(new TextBlock()
                {
                    Text = $"Player {winner} wins!",
                    FontSize = 24,
                    FontFamily = new FontFamily("Arial Black"),
                });

                var positions = GetWinnerAdvanced()!;
                foreach(var pos in positions)
                {
                    Borders[pos.Row, pos.Column].Background = Brushes.Red;
                }
            }
        }
    }

    private char GetWinner()
    {
        char winner = ' ';

        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (TextBlocks[i, 0].Text == TextBlocks[i, 1].Text
                && TextBlocks[i, 1].Text == TextBlocks[i, 2].Text
                && TextBlocks[i, 0].Text != "")
            {
                winner = TextBlocks[i, 0].Text[0];
                break;
            }
        }

        if (winner != ' ') { return winner; }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (TextBlocks[0, i].Text == TextBlocks[1, i].Text
                && TextBlocks[1, i].Text == TextBlocks[2, i].Text
                && TextBlocks[0, i].Text != "")
            {
                winner = TextBlocks[0, i].Text[0];
                break;
            }
        }

        if (winner != ' ') { return winner; }

        // Check diagonals
        if (TextBlocks[0, 0].Text == TextBlocks[1, 1].Text
            && TextBlocks[1, 1].Text == TextBlocks[2, 2].Text
            && TextBlocks[0, 0].Text != "")
        {
            winner = TextBlocks[0, 0].Text[0];
        }
        else if (TextBlocks[0, 2].Text == TextBlocks[1, 1].Text
            && TextBlocks[1, 1].Text == TextBlocks[2, 0].Text
            && TextBlocks[0, 2].Text != "")
        {
            winner = TextBlocks[0, 2].Text[0];
        }

        return winner;
    }

    private Position[]? GetWinnerAdvanced()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (TextBlocks[i, 0].Text == TextBlocks[i, 1].Text
                && TextBlocks[i, 1].Text == TextBlocks[i, 2].Text
                && TextBlocks[i, 0].Text != "")
            {
                return [new Position(i, 0), new Position(i, 1), new Position(i, 2)];
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (TextBlocks[0, i].Text == TextBlocks[1, i].Text
                && TextBlocks[1, i].Text == TextBlocks[2, i].Text
                && TextBlocks[0, i].Text != "")
            {
                return [new Position(0, i), new Position(1, i), new Position(2, i)];
            }
        }

        // Check diagonals
        if (TextBlocks[0, 0].Text == TextBlocks[1, 1].Text
            && TextBlocks[1, 1].Text == TextBlocks[2, 2].Text
            && TextBlocks[0, 0].Text != "")
        {
            return [new Position(0, 0), new Position(1, 1), new Position(2, 2)];
        }
        else if (TextBlocks[0, 2].Text == TextBlocks[1, 1].Text
            && TextBlocks[1, 1].Text == TextBlocks[2, 0].Text
            && TextBlocks[0, 2].Text != "")
        {
            return [new Position(0, 2), new Position(1, 1), new Position(2, 0)];
        }

        return null;
    }
}

record Position(int Row, int Column);