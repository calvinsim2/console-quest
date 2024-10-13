using MazeGameDomain.Commons.Skills;
using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.GenerateMonsters
{
    public static class IceCavernMonsters
    {
        public static IceCavernMonsterParameter GenerateIceSlime()
        {
            MonsterSkill iceSludge = MonsterSkillsCreation.MonsterCustomSkills("Ice Sludge", 5, 0);
            IceCavernMonsterParameter iceSlime = new IceCavernMonsterParameter("Ice Slime", 30, 0, new List<MonsterSkill> { iceSludge });

            return iceSlime;
        }
    }
}
