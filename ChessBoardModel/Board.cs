using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardConsoleApp
{
    public class Board
    {
        public int Size { get; set; }
        public Cell[,] theGrid;
        public int nextRow;
        public int nextCol;

        public Board(int s)
        {
            Size = s;

            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        // Check if a move would take the piece off the board
        public bool validateOutOfRange(int row, int column)
        {
            return row < this.Size && column < this.Size && row >= 0 && column >= 0;
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            // Step 1 - clear all LegalMoves from previous turn.
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                }
            }
            // Step 2 - find all legal moves and mark the square.
            switch (chessPiece)
            {
                case "Knight":
                    {
                        if (validateOutOfRange(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                        {
                            theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }

                        if (validateOutOfRange(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        {
                            theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }

                        if (validateOutOfRange(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        {
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                        }

                        if (validateOutOfRange(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        {
                            theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                        }

                        if (validateOutOfRange(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        {
                            theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }

                        if (validateOutOfRange(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                        {
                            theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }

                        if (validateOutOfRange(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                        {
                            theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                        }

                        if (validateOutOfRange(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        {
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                        }

                        break;
                    }
                case "King":
                    {
                        // Move up 1
                        if (validateOutOfRange(currentCell.RowNumber - 1, currentCell.ColumnNumber))
                        {
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                        // Move down 1
                        if (validateOutOfRange(currentCell.RowNumber + 1, currentCell.ColumnNumber))
                        {
                            theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextMove = true;
                        }
                        // Move left 1
                        if (validateOutOfRange(currentCell.RowNumber, currentCell.ColumnNumber - 1))
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }
                        // Move right 1
                        if (validateOutOfRange(currentCell.RowNumber, currentCell.ColumnNumber + 1))
                        {
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }
                        // Move up and left diagonal 1
                        if (validateOutOfRange(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                        {
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }
                        // Move up and right diagonal 1
                        if (validateOutOfRange(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        {
                            theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }
                        // Move down and left diagonal 1
                        if (validateOutOfRange(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        {
                            theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                        }
                        // Move down and right diagonal 1
                        if (validateOutOfRange(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        {
                            theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                        }
                        break;
                    }
                case "Rook":
                    {
                        // Move up
                        nextRow = currentCell.RowNumber - 1;
                        while (validateOutOfRange(nextRow, currentCell.ColumnNumber))
                        {
                            theGrid[nextRow, currentCell.ColumnNumber].LegalNextMove = true;
                            nextRow--;
                        }

                        // Move down
                        nextRow = currentCell.RowNumber + 1;
                        while (validateOutOfRange(nextRow, currentCell.ColumnNumber))
                        {
                            theGrid[nextRow, currentCell.ColumnNumber].LegalNextMove = true;
                            nextRow++;
                        }

                        // Move left
                        nextCol = currentCell.ColumnNumber - 1;
                        while (validateOutOfRange(currentCell.RowNumber, nextCol))
                        {
                            theGrid[currentCell.RowNumber, nextCol].LegalNextMove = true;
                            nextCol--;
                        }

                        // Move right
                        nextCol = currentCell.ColumnNumber + 1;
                        while (validateOutOfRange(currentCell.RowNumber, nextCol))
                        {
                            theGrid[currentCell.RowNumber, nextCol].LegalNextMove = true;
                            nextCol++;
                        }
                        break;
                    }
                case "Bishop":
                    {
                        // Move up and left diagnoal
                        nextRow = currentCell.RowNumber - 1;
                        nextCol = currentCell.ColumnNumber - 1;
                        while (validateOutOfRange(nextRow, nextCol))
                        {
                            theGrid[nextRow, nextCol].LegalNextMove = true;
                            nextRow--;
                            nextCol--;
                        }

                        // Move up and right diagonal
                        nextRow = currentCell.RowNumber - 1;
                        nextCol = currentCell.ColumnNumber + 1;
                        while (validateOutOfRange(nextRow, nextCol))
                        {
                            theGrid[nextRow, nextCol].LegalNextMove = true;
                            nextRow--;
                            nextCol++;
                        }

                        // Move down and left diagonal
                        nextRow = currentCell.RowNumber + 1;
                        nextCol = currentCell.ColumnNumber - 1;
                        while (validateOutOfRange(nextRow, nextCol))
                        {
                            theGrid[nextRow,nextCol].LegalNextMove = true;
                            nextRow++;
                            nextCol--;
                        }

                        // Move down and right diagonal
                        nextRow = currentCell.RowNumber + 1;
                        nextCol = currentCell.ColumnNumber + 1;
                        while (validateOutOfRange(nextRow, nextCol))
                        {
                            theGrid[nextRow, nextCol].LegalNextMove = true;
                            nextRow++;
                            nextCol++;
                        }
                        break;
                    }
                case "Queen":
                    {
                        // Move up
                        nextRow = currentCell.RowNumber - 1;
                        while (validateOutOfRange(nextRow, currentCell.ColumnNumber))
                        {
                            theGrid[nextRow, currentCell.ColumnNumber].LegalNextMove = true;
                            nextRow--;
                        }

                        // Move down
                        nextRow = currentCell.RowNumber + 1;
                        while (validateOutOfRange(nextRow, currentCell.ColumnNumber))
                        {
                            theGrid[nextRow, currentCell.ColumnNumber].LegalNextMove = true;
                            nextRow++;
                        }

                        // Move left
                        nextCol = currentCell.ColumnNumber - 1;
                        while (validateOutOfRange(currentCell.RowNumber, nextCol))
                        {
                            theGrid[currentCell.RowNumber, nextCol].LegalNextMove = true;
                            nextCol--;
                        }

                        // Move right
                        nextCol = currentCell.ColumnNumber + 1;
                        while (validateOutOfRange(currentCell.RowNumber, nextCol))
                        {
                            theGrid[currentCell.RowNumber, nextCol].LegalNextMove = true;
                            nextCol++;
                        }

                        // Move up and left diagnoal
                        nextRow = currentCell.RowNumber - 1;
                        nextCol = currentCell.ColumnNumber - 1;
                        while (validateOutOfRange(nextRow, nextCol))
                        {
                            theGrid[nextRow, nextCol].LegalNextMove = true;
                            nextRow--;
                            nextCol--;
                        }

                        // Move up and right diagonal
                        nextRow = currentCell.RowNumber - 1;
                        nextCol = currentCell.ColumnNumber + 1;
                        while (validateOutOfRange(nextRow, nextCol))
                        {
                            theGrid[nextRow, nextCol].LegalNextMove = true;
                            nextRow--;
                            nextCol++;
                        }

                        // Move down and left diagonal
                        nextRow = currentCell.RowNumber + 1;
                        nextCol = currentCell.ColumnNumber - 1;
                        while (validateOutOfRange(nextRow, nextCol))
                        {
                            theGrid[nextRow, nextCol].LegalNextMove = true;
                            nextRow++;
                            nextCol--;
                        }

                        // Move down and right diagonal
                        nextRow = currentCell.RowNumber + 1;
                        nextCol = currentCell.ColumnNumber + 1;
                        while (validateOutOfRange(nextRow, nextCol))
                        {
                            theGrid[nextRow, nextCol].LegalNextMove = true;
                            nextRow++;
                            nextCol++;
                        }
                        break;
                    }
            }    
        }
    }
}
