using MazeGameDomain.Builders;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Skills
{
    public static class AdventurerSkillsCreation
    {
        public static AdventurerSkill AdventurerCustomSkills(string skillName, decimal damage, decimal mpCost)
        {
            return new AdventurerSkillBuilder().SetName(skillName).SetDamage(damage).SetMpCost(mpCost).Build();
        }

        public static ICollection<AdventurerSkill> WarriorDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill swordSlash = new AdventurerSkillBuilder().SetName("Sword Slash").SetDamage(10m).SetMpCost(0m).Build();
            AdventurerSkill advancedBrandish = new AdventurerSkillBuilder().SetName("Advanced Brandish").SetDamage(20m).SetMpCost(5m).Build();
            AdventurerSkill heavenHammer = new AdventurerSkillBuilder().SetName("Heaven's Hammer").SetDamage(50m).SetMpCost(30m).Build();
            defaultSkills.Add(swordSlash);
            defaultSkills.Add(advancedBrandish);
            defaultSkills.Add(heavenHammer);

            return defaultSkills;
        }

        public static ICollection<AdventurerSkill> MagicianDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill magicClaw = new AdventurerSkillBuilder().SetName("Magic Claw").SetDamage(15m).SetMpCost(0m).Build();
            AdventurerSkill quantumExplosion = new AdventurerSkillBuilder().SetName("Quantum Explosion").SetDamage(30m).SetMpCost(15m).Build();
            defaultSkills.Add(magicClaw);
            defaultSkills.Add(quantumExplosion);

            return defaultSkills;
        }

        public static ICollection<AdventurerSkill> BowmanDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill doubleShot = new AdventurerSkillBuilder().SetName("Double Shot").SetDamage(15m).SetMpCost(0m).Build();
            AdventurerSkill arrowBlow = new AdventurerSkillBuilder().SetName("Arrow Blow").SetDamage(25m).SetMpCost(10m).Build();
            defaultSkills.Add(doubleShot);
            defaultSkills.Add(doubleShot);

            return defaultSkills;
        }
    }
}
