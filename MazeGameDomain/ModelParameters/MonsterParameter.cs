using MazeGameDomain.Enums;
using MazeGameDomain.Models;
using MazeGameDomain.Models.Monsters;

namespace MazeGameDomain.ModelParameters
{
    public abstract class MonsterParameter
    {
        public string Name { get; set; } = string.Empty;
        public decimal Health { get; set; }
        public decimal MP { get; set; }
        public int Type { get; set; }

        public ICollection<MonsterSkill> MonsterSkills { get; set; } = new List<MonsterSkill>();
    }

    public class IceCavernMonsterParameter : MonsterParameter
    {
        public IceCavernMonsterParameter(string name, decimal health, decimal mp, ICollection<MonsterSkill> monsterSkills)
        {
            Name = name;
            Health = health;
            MP = mp;
            Type = (int)ElementType.Ice;
            MonsterSkills = monsterSkills;
        }
    }

    public class FireCavernMonsterParameter : MonsterParameter
    {
        public FireCavernMonsterParameter(string name, decimal health, decimal mp, ICollection<MonsterSkill> monsterSkills)
        {
            Name = name;
            Health = health;
            MP = mp;
            Type = (int)ElementType.Fire;
            MonsterSkills = monsterSkills;
        }
    }

    public class ThickForestMonsterParameter : MonsterParameter
    {
        public ThickForestMonsterParameter(string name, decimal health, decimal mp, ICollection<MonsterSkill> monsterSkills)
        {
            Name = name;
            Health = health;
            MP = mp;
            Type = (int)ElementType.Earth;
            MonsterSkills = monsterSkills;
        }
    }

    public class SkyCastleMonsterParameter : MonsterParameter
    {
        public SkyCastleMonsterParameter(string name, decimal health, decimal mp, ICollection<MonsterSkill> monsterSkills)
        {
            Name = name;
            Health = health;
            MP = mp;
            Type = (int)ElementType.Neutral;
            MonsterSkills = monsterSkills;
        }
    }
}
