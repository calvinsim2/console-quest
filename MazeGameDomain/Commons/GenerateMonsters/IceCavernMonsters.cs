using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models;
using MazeGameDomain.Models.Monsters;

namespace MazeGameDomain.Commons.GenerateMonsters
{
    public static class IceCavernMonsters
    {
        public static IceCavernMonsterParameter GenerateIceSlime()
        {
            MonsterSkill iceSludge = new MonsterSkill("Ice Sludge", 5, 0);
            IceCavernMonsterParameter iceSlime = new IceCavernMonsterParameter("Ice Slime", 30, 0, new List<MonsterSkill> { iceSludge });

            return iceSlime;
        }
    }
}
