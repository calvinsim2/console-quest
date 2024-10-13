namespace MazeGameDomain.Models
{
    public abstract class Skill
    {
        public string SkillName { get; set; } = string.Empty;
        public decimal EffectPower { get; set; }
        public decimal MpCost { get; set; }
        public bool IsUtility { get; set; }
        public int AttributeTarget { get; set; }
    }

    public class MonsterSkill : Skill
    {
    }

    public class AdventurerSkill : Skill
    {
    }
}
