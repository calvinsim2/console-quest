using MazeGameDomain.Enums;

namespace MazeGameDomain.Models
{
    public class Adventurer
    {
        public string Name { get; set; } = string.Empty;
        public decimal Health { get; set; } 
        public int Class { get; set; }
        public Specialisation Specialisation { get; set; }
        public ICollection<string> Inventory { get; set; } = new List<string>();

        public Adventurer() { }
    }
}
