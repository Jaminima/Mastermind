using System;
using System.Linq;

namespace Mastermind
{
    public enum Peg
    {
        Red, Green, Blue, White, Black, Pink, Gray, Yellow
    }

    public class GameRound
    {
        #region Fields

        private static Random rnd = new Random(DateTime.Now.Millisecond);
        private Peg[,] attempts = new Peg[9, PegWidth];
        private Peg[] solution = new Peg[PegWidth];
        public static int PegWidth = 4;
        public uint attempt_count = 0;

        #endregion Fields

        #region Methods

        public bool AttemptMatches()
        {
            for (int i = 0; i < PegWidth; i++)
            {
                if (attempts[attempt_count, i] != solution[i]) return false;
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
            Peg[] Pegs = GetPegInput();

            if (Pegs != null)
            {
                for (int i = 0; i < PegWidth; i++) attempts[attempt_count, i] = Pegs[i];
            }
        }

        public void GetNewSolution()
        {
            Peg[] Pegs = GetPegInput();

            solution = Pegs;
        }

        public Peg[] GetPegInput()
        {
            Peg[] pegs = new Peg[PegWidth];

            string input = Console.ReadLine().Trim();

            string[] segments = input.Split(' ');

            if (segments.Length < PegWidth)
            {
                Console.WriteLine("Not enough segments");
                GetNewAttempt();
                return null;
            }

            for (int i = 0; i < PegWidth; i++)
            {
                if (int.TryParse(segments[i], out int k))
                {
                    pegs[i] = (Peg)k;
                }
                else
                {
                    Console.WriteLine($"Invalid Input \'{segments[i]}\'");
                    GetNewAttempt();
                    return null;
                }
            }

            return pegs;
        }

        public void RandomSolution()
        {
            for (int i = 0; i < PegWidth; i++)
            {
                solution[i] = (Peg)rnd.Next(0, 8);
            }
        }

        #endregion Methods
    }
}
