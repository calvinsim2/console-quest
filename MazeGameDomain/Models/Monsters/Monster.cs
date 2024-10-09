using MazeGameDomain.Interfaces.Monsters;

namespace MazeGameDomain.Models.Monsters
{
    public abstract class Monster : IMonster
    {
        public string Name { get; set; } = string.Empty;
        public decimal Health { get; set; }
        public decimal MP { get; set; }
        public int Type { get; set; }

        public ICollection<MonsterSkill> MonsterSkills { get; set; } = new List<MonsterSkill>();
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
