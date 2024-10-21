namespace MazeGameDomain.Models
{
    /// <summary>
    /// Represents an instance that stores information required throughout the game. 
    /// </summary>
    /// <remarks>
    /// The MazeGameDataModel Class exists to store dynamic parameters that mutates throughout the game
    /// </remarks>
    public class MazeGameDataModel
    {
        public Adventurer Adventurer { get; set; } = new Adventurer();
        public MazeGameDataModel() { }
    }
}
