using MazeGameDomain.Models;

namespace MazeGameDomain.Builders
{
    public abstract class SkillBuilder<T> where T : Skill, new()
    {
        protected T skill = new T();

        public SkillBuilder<T> SetName(string name)
        {
            skill.SkillName = name;
            return this;
        }

        public SkillBuilder<T> SetEffectPower(decimal effectPower)
        {
            skill.EffectPower = effectPower;
            return this;
        }

        public SkillBuilder<T> SetMpCost(decimal mpCost)
        {
            skill.MpCost = mpCost;
            return this;
        }

        public SkillBuilder<T> SetAttackType(int setAttackType)
        {
            skill.AttackType = setAttackType;
            return this;
        }

        public SkillBuilder<T> SetIsUtility(bool isUtility)
        {
            skill.IsUtility = isUtility;
            return this;
        }

        public SkillBuilder<T> SetAttributeTarget(int setAttributeTarget)
        {
            skill.AttributeTarget = setAttributeTarget;
            return this;
        }

        public T Build()
        {
            return skill;
        }
    }

    public class MonsterSkillBuilder : SkillBuilder<MonsterSkill>
    {
    }

    public class AdventurerSkillBuilder : SkillBuilder<AdventurerSkill>
    {
    }
}
