using MazeGameDomain.Builders;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Skills.Adventurer
{
    public static class MagicianSkills
    {
        public static ICollection<AdventurerSkill> MagicianDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill magicClaw = new AdventurerSkillBuilder().SetName("Magic Claw").SetDamage(15m).SetMpCost(0m).Build();
            AdventurerSkill quantumExplosion = new AdventurerSkillBuilder().SetName("Quantum Explosion").SetDamage(30m).SetMpCost(15m).Build();
            defaultSkills.Add(magicClaw);
            defaultSkills.Add(quantumExplosion);

            return defaultSkills;
        }

        public static AdventurerSkill MagicianCustomSkills(string skillName, decimal damage, decimal mpCost)
        {
            return new AdventurerSkillBuilder().SetName(skillName).SetDamage(damage).SetMpCost(mpCost).Build();
        }
    }
}
