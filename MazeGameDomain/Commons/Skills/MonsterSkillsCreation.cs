using MazeGameDomain.Builders;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Skills
{
    public static class MonsterSkillsCreation
    {
        public static MonsterSkill MonsterCustomSkills(string skillName, decimal damage, decimal mpCost)
        {
            return new MonsterSkillBuilder().SetName(skillName).SetDamage(damage).SetMpCost(mpCost).Build();
        }
    }
}
