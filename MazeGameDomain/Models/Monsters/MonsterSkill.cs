namespace MazeGameDomain.Models.Monsters
{
    public class MonsterSkill
    {
        public string SkillName { get; set; } = string.Empty;

        public decimal Damage { get; set; }
        public decimal MpCost { get; set; }
    }
}
