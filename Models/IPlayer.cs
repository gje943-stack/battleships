namespace BattleshipEngine.Models
{
    public interface IPlayer
    {
        IBoard Board { get; set; }
        int PlayerId { get; init; }
    }
}