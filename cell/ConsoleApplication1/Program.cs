﻿using System;
using System.Collections.Generic;
using ConsoleApplication1.bots;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main()
		{
			var bots = new List<IBot>();

			var bot1 = new BotOne();
			var player1 = new Player { Name = "p1" };
			bot1.SetPlayer(player1);
			bots.Add(bot1);

			var bot2 = new DoNothingBot();
			var player2 = new Player { Name = "p2" };
			bot2.SetPlayer(player2);
			bots.Add(bot2);

			var board = new Board();
			board.AddPlayer(player1);
			board.AddPlayer(player2);

			var fortUpperRight = new Fort { Location = new Point { X = 8, Y = 8 }, BirthSpeed = 0, FortOwner = player2 };
			var fortUpperLeft = new Fort { Location = new Point { X = 2, Y = 8 }, BirthSpeed = 0};
			var fortLowerRight = new Fort { Location = new Point { X = 8, Y = 2 }, BirthSpeed = 0};
			var fortLowerLeft = new Fort { Location = new Point { X = 2, Y = 2 }, BirthSpeed = 5, FortOwner = player1 };
			board.AddFort(fortUpperRight);
			board.AddFort(fortUpperLeft);
			board.AddFort(fortLowerRight);
			board.AddFort(fortLowerLeft);

			var winner = board.GetTheWinner();

			while (winner == null)
			{
				board.CreateGuys();
				board.MoveGuyGroups();

				foreach (var bot in bots)
				{
					bot.Do(board);
				}

				Console.WriteLine($"{Environment.NewLine}Turn:{board.Turn++}");
				PrintGameState(board);
				winner = board.GetTheWinner();
			}
			Console.WriteLine("The Winner is " + winner.Name);

			Console.ReadLine();
		}

		public static void PrintGameState(Board board)
		{
			foreach (var fort in board.Forts)
			{
				Console.WriteLine(fort.GetDescription());
			}

			foreach (var gg in board.TravelingGGs)
			{
				Console.WriteLine(gg.GetDescription());
			}
		}
	}
}
