using MazeGameDomain.Builders;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Skills
{
    public static class MonsterSkillsCreation
    {
        public static MonsterSkill MonsterCustomOffensiveSkill(string skillName, decimal effectPower, int attackType, decimal mpCost)
        {
            return new MonsterSkillBuilder().SetName(skillName).SetEffectPower(effectPower).SetAttackType(attackType).SetMpCost(mpCost).Build();
        }

        public static MonsterSkill MonsterCustomUtilitySkill(string skillName, decimal effectPower, decimal mpCost, int attributeTarget)
        {
            return new MonsterSkillBuilder().SetName(skillName).SetEffectPower(effectPower).SetMpCost(mpCost).SetIsUtility(true).SetAttributeTarget(attributeTarget).Build();
        }
    }
}
