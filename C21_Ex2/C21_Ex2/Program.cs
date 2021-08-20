using System;
using System.Collections.Generic;
using System.Linq;

namespace C21_Ex2
{
    class MainClass
    {
		static void Main(string[] args)
		{
			var stillPlaying = true;

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine("-----------------------");
			Console.WriteLine("Welcome to Tic Tac Toe!");
			Console.WriteLine("-----------------------\n");
			Console.ResetColor();

			while (stillPlaying)
			{
				Console.WriteLine("What would you like to do:");
				Console.WriteLine("1. Start a new game");
				Console.WriteLine("2. Quit\n");

				Console.Write("Type a number and hit <enter>: ");

				var choice = GetUserInput("[12]");

				switch (choice)
				{
					case "1":
						PlayGame();
						Console.Clear();
						break;
					case "2":
						stillPlaying = false;
						break;
				}
			}
		}

		private static string GetUserInput(string validPattern = null)
		{
			var input = Console.ReadLine();
			input = input.Trim();

			if (validPattern != null && !System.Text.RegularExpressions.Regex.IsMatch(input, validPattern))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("\"" + input + "\" is not valid.\n");
				Console.ResetColor();
				return null;
			}

			return input;
		}

		private static void PlayGame()
		{
			string numRowsChoice = null;
			while (numRowsChoice == null)
			{
				Console.Write("How many rows do you want to have? (3, 4, or 5) ");
				numRowsChoice = GetUserInput("[345]");
			}
			var boardSize = int.Parse(numRowsChoice);
			Board boardgrid = new Board(boardSize);

			var turn = "X";
			while (true)
			{
				Console.Clear();

				var winner = boardgrid.GetWinner();
				if (winner != null)
				{
					AnnounceResult(winner[0] + " WINS!!!");
					boardgrid.DrawBoard();
					break;
				}
				if (boardgrid.IsBoardFull())
				{
					AnnounceResult("It's a tie!!!");
					boardgrid.DrawBoard();
					break;
				}

				Console.WriteLine("Place your " + turn + ":");

				boardgrid.DrawBoard();

				var xoLoc = handleNextTurn(boardgrid);
				boardgrid.SetCell(xoLoc, turn);

				turn = turn == "X" ? "O" : "X";
			}
		}

		private static void AnnounceResult(string message)
		{
			Console.WriteLine();

			Console.ForegroundColor = ConsoleColor.DarkGreen;
			Console.WriteLine(message);
			Console.ResetColor();

			Console.Write("\nPress any key to continue...");
			Console.CursorVisible = false;
			Console.ReadKey();
			Console.CursorVisible = true;
		}

		private static int handleNextTurn(Board boardgrid)
		{
			while (true)
            {
				Console.WriteLine("\nEnter a column and press <enter>");
				var inputColStr = Console.ReadLine();
				int inputCol = int.Parse(inputColStr);

				if (!boardgrid.IsBoardColumnValid(inputCol))
                {
					Console.WriteLine("\nColumn out of range");
				}

				for (int row = boardgrid.BoardGridSize - 1; row >= 0 ; row--)
				{
					if (boardgrid.GetCell(row, inputCol) == null)
                    {
						return row * boardgrid.BoardGridSize + inputCol;
					}

				}
				Console.WriteLine("\nColumn full");
			}
		}
	}
}
