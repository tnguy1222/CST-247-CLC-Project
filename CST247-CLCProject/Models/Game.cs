
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CST247_CLCProject.Models
{
    public class Game
    {
        public Board board { get; set; }

        public int numberClick { get; set; }

        public int levelChoice { get; set; }
        public Cell RowNumber;
        public Cell ColumnNumber;
        public Game(Board board, int numberClick, int levelChoice)
        {
            this.board = board;
            this.numberClick = numberClick;
            this.levelChoice = levelChoice;
        }

        public Game()
        {
            this.board = new Board(8, 10);
            this.numberClick = 0;
            this.levelChoice = 10;
        }

        public void PlaceTurn(int rowNumber, int columNumber)
        {

            if (board.isValidate(rowNumber, columNumber) && board.theGrid[rowNumber, columNumber].hasABomb == false)
            {


                if (this.board.theGrid[rowNumber, columNumber].numberNeighborBombs == 0)
                {

                    board.floodFill(rowNumber, columNumber);
                }
                if (checkWinCondition())
                {
                    Debug.WriteLine("You win");
                }

            }

            else if (board.isValidate(rowNumber, columNumber) && this.board.theGrid[rowNumber, columNumber].hasABomb == true)
            {
                // when user clicked a bomb, 
                for (int i = 0; i < board.Size; i++)
                {
                    for (int j = 0; j < board.Size; j++)
                    {
                        board.theGrid[i, j].isVisited = true;
                    }
                }
                Debug.WriteLine("You lost");
            }


        }


        public bool checkWinCondition()
        {

            bool winCondition = true;
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    // if there exitst one square that has not been visited and is bomb free the player hasn't won yet
                    if (board.theGrid[i, j].isVisited == false && board.theGrid[i, j].hasABomb == false)
                    {
                        winCondition = false;
                    }
                }

            }
            return winCondition;
        }

    }
}