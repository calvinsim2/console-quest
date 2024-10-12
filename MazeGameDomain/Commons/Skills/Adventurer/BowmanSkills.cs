using MazeGameDomain.Builders;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Skills.Adventurer
{
    public static class BowmanSkills
    {
        public static ICollection<AdventurerSkill> BowmanDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill doubleShot = new AdventurerSkillBuilder().SetName("Double Shot").SetDamage(15m).SetMpCost(0m).Build();
            AdventurerSkill arrowBlow = new AdventurerSkillBuilder().SetName("Arrow Blow").SetDamage(25m).SetMpCost(10m).Build();
            defaultSkills.Add(doubleShot);
            defaultSkills.Add(doubleShot);

            return defaultSkills;
        }

        public static AdventurerSkill BowmanCustomSkills(string skillName, decimal damage, decimal mpCost)
        {
            return new AdventurerSkillBuilder().SetName(skillName).SetDamage(damage).SetMpCost(mpCost).Build();
        }
    }
}
