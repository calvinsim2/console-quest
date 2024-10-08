using MazeGameDomain.Enums;

namespace MazeGameDomain.Models
{
    public class Adventurer
    {
        public string Name { get; set; } = string.Empty;
        public int Health { get; set; } 
        public Class Class { get; set; }
        public Specialisation Specialisation { get; set; }
        public IEnumerable<string> Inventory { get; set; } = new List<string>();

        public Adventurer() { }
    }
}
