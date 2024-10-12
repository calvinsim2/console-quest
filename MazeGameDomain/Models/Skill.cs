namespace MazeGameDomain.Models
{
    public abstract class Skill
    {
        public string SkillName { get; set; } = string.Empty;
        public decimal Damage { get; set; }
        public decimal MpCost { get; set; }
    }

    public class MonsterSkill : Skill
    {
        public MonsterSkill(string skillName, decimal damage, decimal mpCost)
        {
            SkillName = skillName;
            Damage = damage;
            MpCost = mpCost;
        }

        public MonsterSkill() { }
    }

    public class AdventurerSkill : Skill
    {
        public AdventurerSkill(string skillName, decimal damage, decimal mpCost)
        {
            SkillName = skillName;
            Damage = damage;
            MpCost = mpCost;
        }

        public AdventurerSkill() { }
    }
}
