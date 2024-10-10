using MazeGameDomain.Enums;

namespace MazeGameDomain.Models
{
    public class Adventurer
    {
        public string Name { get; set; } = string.Empty;
        public decimal Health { get; set; } 
        public decimal MP { get; set; } 
        public int Class { get; set; }
        public int Specialisation { get; set; }
        public ICollection<AdventurerSkill> Skills { get; set; }
        public ICollection<string> Inventory { get; set; } = new List<string>();

        public Adventurer() { }
    }
}
