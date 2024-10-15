using MazeGameDomain.Interfaces;

namespace MazeGameDomain.Models
{
    public class Adventurer : IAttributes
    {
        public string Name { get; set; } = string.Empty;
        public decimal Health { get; set; } 
        public decimal MP { get; set; } 
        public int Class { get; set; }
        public int Specialisation { get; set; }
        public ICollection<AdventurerSkill> Skills { get; set; }
        public Dictionary<int, int> Inventory { get; set; } = new Dictionary<int, int>(); 

        public Adventurer() { }

        public void IncreaseHealth(decimal health)
        {
            Health += health;
        }

        public void DecreaseHealth(decimal health)
        {
            Health -= health;

            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void IncreaseMP(decimal mp)
        {
            MP += mp;
        }

        public void DecreaseMP(decimal mp)
        {
            MP -= mp;

            if (MP < 0)
            {
                MP = 0;
            }
        }
    }
}
