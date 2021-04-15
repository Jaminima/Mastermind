namespace Mastermind
{
    public class Player
    {
        #region Fields

        public string Nickname;
        public uint Score = 0;

        #endregion Fields

        #region Constructors

        public Player(string _nick)
        {
            Nickname = _nick;
        }

        #endregion Constructors
    }
}
