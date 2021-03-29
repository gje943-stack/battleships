namespace BattleshipEngine.Models
{
    public interface IPlayer
    {
        IBoard Board { get; set; }
        int PlayerId { get; init; }
        IPlayerStats Stats { get; }

        void TakeShot((int col, int row) targetCoord);
    }
}