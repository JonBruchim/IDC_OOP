using System;
using System.Linq;

namespace C21_Ex2
{
    public class Board
    {
        public Board(int boardSize)
        {
			boardGrid = new string[(int)Math.Pow(boardSize, 2)];
			BoardGridSize = boardSize;
		}

		public void SetCell(int index, string player)
		{
			boardGrid[index] = player;
		}

		public string GetCell(int row, int col)
        {
			return boardGrid[row * BoardGridSize + col];
		}

		public bool IsBoardColumnValid(int col)
        {
			return (col >= 0 && col < BoardGridSize);
        }

		public void DrawBoard()
        {
			var numRows = (int)Math.Sqrt(boardGrid.Length);

			Console.WriteLine();

			for (int row = 0; row < numRows; row++)
			{
				if (row != 0)
					Console.WriteLine(" " + string.Join("|", Enumerable.Repeat("---", numRows)));

				Console.Write(" " + string.Join("|", Enumerable.Repeat("   ", numRows)) + "\n ");

				for (int col = 0; col < numRows; col++)
				{
					if (col != 0)
						Console.Write("|");
					var space = boardGrid[row * numRows + col] ?? " ";
					if (space.Length > 1)
						Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.Write(" " + space[0] + " ");
					Console.ResetColor();
				}

				Console.WriteLine("\n " + string.Join("|", Enumerable.Repeat("   ", numRows)));
			}

			Console.WriteLine();
		}

		public bool IsBoardFull()
        {
			return boardGrid.All(space => space != null);
		}

		public string GetWinner()
        {
			var numRows = (int)Math.Sqrt(boardGrid.Length);

			// Check rows
			for (int row = 0; row < numRows; row++)
			{
				if (boardGrid[row * numRows] != null)
				{
					bool hasTicTacToe = true;
					for (int col = 1; col < numRows && hasTicTacToe; col++)
					{
						if (boardGrid[row * numRows + col] != boardGrid[row * numRows])
							hasTicTacToe = false;
					}
					if (hasTicTacToe)
					{
						// Put an indicator in the board to know which ones are part of the tic tac toe
						for (int col = 0; col < numRows; col++)
							boardGrid[row * numRows + col] += "!";
						return boardGrid[row * numRows];
					}
				}
			}

			// Check columns
			for (int col = 0; col < numRows; col++)
			{
				if (boardGrid[col] != null)
				{
					bool hasTicTacToe = true;
					for (int row = 1; row < numRows && hasTicTacToe; row++)
					{
						if (boardGrid[row * numRows + col] != boardGrid[col])
							hasTicTacToe = false;
					}
					if (hasTicTacToe)
					{
						// Put an indicator in the board to know which ones are part of the tic tac toe
						for (int row = 0; row < numRows; row++)
							boardGrid[row * numRows + col] += "!";
						return boardGrid[col];
					}
				}
			}

			// Check top left -> bottom right diagonal
			if (boardGrid[0] != null)
			{
				bool hasTicTacToe = true;
				for (int row = 1; row < numRows && hasTicTacToe; row++)
				{
					if (boardGrid[row * numRows + row] != boardGrid[0])
						hasTicTacToe = false;
				}
				if (hasTicTacToe)
				{
					// Put an indicator in the board to know which ones are part of the tic tac toe
					for (int row = 0; row < numRows; row++)
						boardGrid[row * numRows + row] += "!";
					return boardGrid[0];
				}
			}

			// Check top right -> bottom left diagonal
			if (boardGrid[numRows - 1] != null)
			{
				bool hasTicTacToe = true;
				for (int row = 1; row < numRows && hasTicTacToe; row++)
				{
					if (boardGrid[row * numRows + (numRows - 1 - row)] != boardGrid[numRows - 1])
						hasTicTacToe = false;
				}
				if (hasTicTacToe)
				{
					// Put an indicator in the board to know which ones are part of the tic tac toe
					for (int row = 0; row < numRows; row++)
						boardGrid[row * numRows + (numRows - 1 - row)] += "!";
					return boardGrid[numRows - 1];
				}
			}

			return null;
		}

        private string[] boardGrid;
        public int BoardGridSize { get; set; }

    }
}
