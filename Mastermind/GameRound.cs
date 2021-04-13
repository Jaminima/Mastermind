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

        private int attempt_count = 0;

        private bool TopAttemptMatches()
        {
            for (int i = 0; i < PegWidth; i++)
            {
                if (attempts[attempt_count,i] != solution[i]) return false;
            }
            return true;
        }
    }
}
