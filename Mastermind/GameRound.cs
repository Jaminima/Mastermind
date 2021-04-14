using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public enum Peg
    {
        Red, Green, Blue, White, Black, Pink, Gray, Yellow
    }

    public class GameRound
    {
        const int PegWidth = 4;

        private Peg[,] attempts = new Peg[9, PegWidth];
        private Peg[] solution = new Peg[PegWidth];

        private static Random rnd = new Random(DateTime.Now.Millisecond);

        private int attempt_count = 0;

        public void RandomSolution()
        {
            for (int i = 0; i < PegWidth; i++)
            {
                solution[i] = (Peg)rnd.Next(0, 8);
            }
        }

        public bool AttemptMatches()
        {
            for (int i = 0; i < PegWidth; i++)
            {
                if (attempts[attempt_count,i] != solution[i]) return false;
            }
            return true;
        }

        public int[] GetArmIndicators()
        {
            int[] Arms = new int[2];

            for (int i = 0; i < PegWidth; i++)
            {
                if (attempts[attempt_count, i] == solution[i]) Arms[0]++;
                else if (solution.Contains(attempts[attempt_count, i])) Arms[1]++;
            }

            return Arms;
        }

        public void GetNewAttempt()
        {
            string input = Console.ReadLine();

            string[] segments = input.Split(' ');

            if (segments.Length < PegWidth)
            {
                Console.WriteLine("Not enough segments");
                return;
            }

            for (int i = 0; i < PegWidth; i++)
            {
                if (int.TryParse(segments[i],out int k))
                {
                    attempts[attempt_count, i] = (Peg)k;
                }
                else
                {
                    Console.WriteLine($"Invalid Input \'{segments[i]}\'");
                    return;
                }
            }
        }
    }
}
