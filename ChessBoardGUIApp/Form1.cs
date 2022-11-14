using ChessBoardConsoleApp;

namespace ChessBoardGUIApp
{
    public partial class Form1 : Form
    {
        static public Board myBoard = new Board(8);
        public Button[,] btnGrid = new Button[myBoard.Size, myBoard.Size];
        private string chessPiece;
        public Form1()
        {
            InitializeComponent();
            populateGrid();
        }

        public void populateGrid()
        {
            // this function will fill the panel1 control with buttons
            int buttonSize = panel1.Width / myBoard.Size;
            panel1.Height = panel1.Width;

            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c] = new Button();

                    // make each button square
                    btnGrid[r, c].Width = buttonSize;
                    btnGrid[r, c].Height = buttonSize;

                    btnGrid[r, c].Click += Grid_Button_Click; // add the same click event to each button
                    panel1.Controls.Add(btnGrid[r, c]); // place button on the panel
                    btnGrid[r, c].Location = new Point(buttonSize * r, buttonSize * c); // position in x,y

                    btnGrid[r, c].Tag = r.ToString() + "|" + c.ToString();
                }
            }
        }

        private void Grid_Button_Click(object? sender, EventArgs e)
        {
            // get the row and column number of the button just clicked.
            string[] strArr = (sender as Button).Tag.ToString().Split("|");
            int r = int.Parse(strArr[0]);
            int c = int.Parse(strArr[1]);

            // run a helper function to label all legal moves for this piece.
            Cell currentCell = myBoard.theGrid[r, c];
            currentCell.CurrentlyOccupied = true;
            myBoard.MarkNextLegalMoves(currentCell, chessPiece);
            updateButtonLabels();

            // reset the background color of all buttons to the default (original) color.
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    btnGrid[i, j].BackColor = default(Color);
                }
            }

            // set the background color of the clicked button to something different.
            (sender as Button).BackColor = Color.Cornsilk;
        }

        public void updateButtonLabels()
        {
            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c].Text = "";
                    if (myBoard.theGrid[r, c].CurrentlyOccupied)
                    {
                        // this isn't working for some reason?
                        btnGrid[r, c].Text = chessPiece;
                    }
                    if (myBoard.theGrid[r, c].LegalNextMove)
                    {
                        btnGrid[r, c].Text = "Legal";
                    }
                    myBoard.theGrid[r, c].CurrentlyOccupied = false;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex != null)
            {
                chessPiece = comboBox1.SelectedItem.ToString();
            }

            for (int r = 0; r < myBoard.Size; r++)
            {
                for (int c = 0; c < myBoard.Size; c++)
                {
                    btnGrid[r, c].Text = "";
                    myBoard.theGrid[r, c].CurrentlyOccupied = false;
                    myBoard.theGrid[r, c].LegalNextMove = false;
                }
            }
        }
    }
}