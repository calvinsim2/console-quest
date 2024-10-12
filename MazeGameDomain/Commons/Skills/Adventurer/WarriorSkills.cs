using MazeGameDomain.Builders;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Skills.Adventurer
{
    public static class WarriorSkills
    {
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

        public static AdventurerSkill WarriorCustomSkills(string skillName, decimal damage, decimal mpCost)
        {
            return new AdventurerSkillBuilder().SetName(skillName).SetDamage(damage).SetMpCost(mpCost).Build();
        }
    }
}
