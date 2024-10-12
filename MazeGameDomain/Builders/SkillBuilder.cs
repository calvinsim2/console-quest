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

        public SkillBuilder<T> SetDamage(decimal damage)
        {
            skill.Damage = damage;
            return this;
        }

        public SkillBuilder<T> SetMpCost(decimal mpCost)
        {
            skill.MpCost = mpCost;
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
