using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    public class Player
    {
        public string Nickname;
        public uint Score = 0;

        public Player(string _nick)
        {
            Nickname = _nick;
        }
    }
}
