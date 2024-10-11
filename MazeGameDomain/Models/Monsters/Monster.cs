using MazeGameDomain.Interfaces;
using MazeGameDomain.Interfaces.Monsters;

namespace MazeGameDomain.Models.Monsters
{
    public abstract class Monster : IMonster, IAttributes
    {
        public string Name { get; set; } = string.Empty;
        public decimal Health { get; set; }
        public decimal MP { get; set; }
        public int Type { get; set; }

        public ICollection<MonsterSkill> MonsterSkills { get; set; } = new List<MonsterSkill>();

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

    public class IceCavernMonster : Monster
    {
        public IceCavernMonster(string name, decimal health, decimal mp, int type, ICollection<MonsterSkill> monsterSkills)
        {
            Name = name;
            Health = health;
            MP = mp;
            Type = type;
            MonsterSkills = monsterSkills;
        }
    }

    public class FireCavernMonster : Monster
    {
        public FireCavernMonster(string name, decimal health, decimal mp, int type, ICollection<MonsterSkill> monsterSkills)
        {
            Name = name;
            Health = health;
            MP = mp;
            Type = type;
            MonsterSkills = monsterSkills;
        }
    }

    public class ThickForestMonster : Monster
    {
        public ThickForestMonster(string name, decimal health, decimal mp, int type, ICollection<MonsterSkill> monsterSkills)
        {
            Name = name;
            Health = health;
            MP = mp;
            Type = type;
            MonsterSkills = monsterSkills;
        }
    }

    public class SkyCastleMonster : Monster
    {
        public SkyCastleMonster(string name, decimal health, decimal mp, int type, ICollection<MonsterSkill> monsterSkills)
        {
            Name = name;
            Health = health;
            MP = mp;
            Type = type;
            MonsterSkills = monsterSkills;
        }
    }
}
