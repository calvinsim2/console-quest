namespace MazeGameDomain.Models
{
    /// <summary>
    /// Provides an encapsulation for skill class that are instantiated in the game.
    /// </summary>
    /// <param name="SkillName">The name of the skill.</param>
    /// <param name="EffectPower">Dictates the potency of the skill.</param>
    /// <param name="MpCost">Dictates the MP required to activate this spell.</param>
    /// <param name="AttackType">Dictates the attack type (Melee, Magic, Ranged).</param>
    /// <param name="IsUtility">Dictates if skill is an utility skill, instead of an offensive skill.</param>
    /// <param name="IsUtility">Dictates the attribute the skill targets, if it is an utility skill.</param>
    public abstract class Skill
    {
        public string SkillName { get; set; } = string.Empty;
        public decimal EffectPower { get; set; }
        public decimal MpCost { get; set; }
        public int AttackType { get; set; }
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
