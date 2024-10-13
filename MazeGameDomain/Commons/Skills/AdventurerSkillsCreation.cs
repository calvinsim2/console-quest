using MazeGameDomain.Builders;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Skills
{
    public static class AdventurerSkillsCreation
    {
        public static AdventurerSkill AdventurerCustomOffensiveSkill(string skillName, decimal effectPower, decimal mpCost)
        {
            return new AdventurerSkillBuilder().SetName(skillName).SetEffectPower(effectPower).SetMpCost(mpCost).Build();
        }

        public static AdventurerSkill AdventurerCustomUtilitySkill(string skillName, decimal effectPower, decimal mpCost, int attributeTarget)
        {
            return new AdventurerSkillBuilder().SetName(skillName).SetEffectPower(effectPower).SetMpCost(mpCost).SetIsUtility(true).SetAttributeTarget(attributeTarget).Build();
        }

        public static ICollection<AdventurerSkill> WarriorDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill swordSlash = new AdventurerSkillBuilder().SetName("Sword Slash").SetEffectPower(10m).SetMpCost(0m).Build();
            AdventurerSkill advancedBrandish = new AdventurerSkillBuilder().SetName("Advanced Brandish").SetEffectPower(20m).SetMpCost(5m).Build();
            AdventurerSkill powerRestore = new AdventurerSkillBuilder().SetName("Power Restore").SetEffectPower(30m).SetMpCost(0m).SetIsUtility(true).SetAttributeTarget(2).Build();
            defaultSkills.Add(swordSlash);
            defaultSkills.Add(advancedBrandish);
            defaultSkills.Add(powerRestore);

            return defaultSkills;
        }

        public static ICollection<AdventurerSkill> MagicianDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill magicClaw = new AdventurerSkillBuilder().SetName("Magic Claw").SetEffectPower(15m).SetMpCost(0m).Build();
            AdventurerSkill quantumExplosion = new AdventurerSkillBuilder().SetName("Quantum Explosion").SetEffectPower(30m).SetMpCost(15m).Build();
            defaultSkills.Add(magicClaw);
            defaultSkills.Add(quantumExplosion);

            return defaultSkills;
        }

        public static ICollection<AdventurerSkill> BowmanDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill doubleShot = new AdventurerSkillBuilder().SetName("Double Shot").SetEffectPower(15m).SetMpCost(0m).Build();
            AdventurerSkill arrowBlow = new AdventurerSkillBuilder().SetName("Arrow Blow").SetEffectPower(25m).SetMpCost(10m).Build();
            defaultSkills.Add(doubleShot);
            defaultSkills.Add(doubleShot);

            return defaultSkills;
        }
    }
}
