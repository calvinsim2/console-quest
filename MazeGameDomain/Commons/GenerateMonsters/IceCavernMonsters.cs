using MazeGameDomain.Commons.Skills;
using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.GenerateMonsters
{
    public static class IceCavernMonsters
    {
        public static IceCavernMonsterParameter GenerateIceSlime()
        {
            MonsterSkill iceSludge = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Ice Sludge", 5, 0);
            IceCavernMonsterParameter iceSlime = new IceCavernMonsterParameter("Ice Slime", 30, 0, new List<MonsterSkill> { iceSludge });

            return iceSlime;
        }

        public static IceCavernMonsterParameter GenerateIceBoar()
        {
            MonsterSkill icyCharge = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Icy Charge", 10, 0);
            MonsterSkill coldTuskImpale = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Cold Tusk Impale", 20, 10);
            IceCavernMonsterParameter iceBoar = new IceCavernMonsterParameter("Ice Boar", 50, 20, new List<MonsterSkill> { icyCharge, coldTuskImpale });

            return iceBoar;
        }

        public static IceCavernMonsterParameter GenerateIceYeti()
        {
            MonsterSkill iceFist = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Ice Fist", 10, 0);
            MonsterSkill icyHowl = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Icy Howl", 15, 10);
            MonsterSkill earthQuake = MonsterSkillsCreation.MonsterCustomOffensiveSkill("EarthQuake", 40, 30);
            IceCavernMonsterParameter iceYeti = new IceCavernMonsterParameter("Ice Yeti", 70, 40, new List<MonsterSkill> { iceFist, icyHowl, earthQuake });

            return iceYeti;
        }
    }
}
