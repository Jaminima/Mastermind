using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public static class GameManager
    {
        private static List<GameRound> gameRounds = new List<GameRound>();

        public static void Play()
        {
            GameRound activeRound;
            while (true)
            {
                activeRound = new GameRound(); 
                gameRounds.Add(activeRound);

                activeRound.RandomSolution();

                while (activeRound.AnotherAttempt())
                {
                    activeRound.GetNewAttempt();

                    int[] arms = activeRound.GetArmIndicators();
                    Console.WriteLine($"Correct Peg & Position {arms[0]}\nCorrect Peg Not Position {arms[1]}");
                }

                Console.WriteLine($"Codemaker scored {activeRound.attempt_count}");
            }
        }
    }
}
