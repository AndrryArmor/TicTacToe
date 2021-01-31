namespace Core.Entities
{
    public class VictoryEventArgs
    {
        public VictoryEventArgs(Player winner)
        {
            Winner = winner;
        }

        public Player Winner { get; }
    }
}