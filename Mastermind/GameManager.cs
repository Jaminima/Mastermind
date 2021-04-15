using System;
using System.Collections.Generic;

namespace Mastermind
{
    public static class GameManager
    {
        #region Fields

        private static List<GameRound> gameRounds = new List<GameRound>();

        private static Player[] players = new Player[2] { new Player("Player 0"), new Player("Player 1") };
        private static int playerSwitch = 0;

        #endregion Fields

        #region Methods

        private static void GetPlayerNames()
        {
            Console.WriteLine("Player 0 Nickname: ");
            players[0].Nickname = Console.ReadLine();
            Console.WriteLine("Player 1 Nickname: ");
            players[1].Nickname = Console.ReadLine();
        }

        public static void Play()
        {
            GetPlayerNames();

            Console.WriteLine($"Peg Combinations Compose of {GameRound.PegWidth} * Values (0-7)");

            GameRound activeRound;
            while (true)
            {
                activeRound = new GameRound();
                gameRounds.Add(activeRound);

                Console.WriteLine($"{players[(playerSwitch + 1) % 2].Nickname} Input A Target Peg Combination: ");
                activeRound.GetNewSolution();

                Console.Clear();
                Console.WriteLine($"{players[playerSwitch].Nickname} Input Your {GameRound.PegWidth} Peg Combination Attempts: ");

                while (activeRound.attempt_count < 9)
                {
                    Console.Write($"{activeRound.attempt_count}/9: ");
                    activeRound.GetNewAttempt();

                    int[] arms = activeRound.GetArmIndicators();
                    Console.WriteLine($"Correct Peg & Position {arms[0]}\nCorrect Peg Not Position {arms[1]}");

                    if (activeRound.AttemptMatches()) break;

                    activeRound.attempt_count++;
                }

                players[playerSwitch].Score += activeRound.attempt_count;
                Console.WriteLine($"Codemaker ({players[playerSwitch].Nickname}) scored {activeRound.attempt_count} now you have {players[playerSwitch].Score} points.");

                playerSwitch = (playerSwitch + 1) % 2;
            }
        }

        #endregion Methods
    }
}
