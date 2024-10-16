using MazeGameDomain.Commons.Skills;
using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.GenerateMonsters
{
    public static class FireCavernMonsters
    {
        public static FireCavernMonsterParameter GenerateFireSlime()
        {
            MonsterSkill flameSludge = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Flame Sludge", 5, 0);
            FireCavernMonsterParameter fireSlime = new FireCavernMonsterParameter("Fire Slime", 30, 0, new List<MonsterSkill> { flameSludge });

            return fireSlime;
        }

        public static FireCavernMonsterParameter GenerateFireBoar()
        {
            MonsterSkill burningCharge = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Burning Charge", 10, 0);
            MonsterSkill flameTuskImpale = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Flame Tusk Impale", 20, 10);
            FireCavernMonsterParameter fireBoar = new FireCavernMonsterParameter("Fire Boar", 50, 20, new List<MonsterSkill> { burningCharge, flameTuskImpale });

            return fireBoar;
        }

        public static FireCavernMonsterParameter GenerateInfernal()
        {
            MonsterSkill flamingFist = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Flaming Fist", 20, 0);
            FireCavernMonsterParameter infernal = new FireCavernMonsterParameter("Infernal", 120, 0, new List<MonsterSkill> { flamingFist });

            return infernal;
        }

        public static FireCavernMonsterParameter GenerateFireDragon()
        {
            MonsterSkill wingAttack = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Wing Attack", 15, 0);
            MonsterSkill burningClaw = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Burning Claw", 25, 20);
            MonsterSkill fireBlast = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Fire Blast", 40, 80);
            FireCavernMonsterParameter fireDragon = new FireCavernMonsterParameter("Fire Dragon", 200, 60, new List<MonsterSkill> { wingAttack, burningClaw, fireBlast });

            return fireDragon;
        }

        public static FireCavernMonsterParameter GenerateLavaMorphling()
        {
            MonsterSkill lavaToss = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Lava Toss", 10, 0);
            MonsterSkill lavaWaveform = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Lava Waveform", 20, 10);
            FireCavernMonsterParameter lavaMorphling = new FireCavernMonsterParameter("Lava Morphling", 70, 20, new List<MonsterSkill> { lavaToss, lavaWaveform });

            return lavaMorphling;
        }

        public static FireCavernMonsterParameter GenerateMagma()
        {
            MonsterSkill moltenPunch = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Molten Punch", 15, 0);
            MonsterSkill flameThrower = MonsterSkillsCreation.MonsterCustomOffensiveSkill("FlameThrower", 25, 20);
            MonsterSkill explosion = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Explosion", 40, 30);
            FireCavernMonsterParameter magma = new FireCavernMonsterParameter("Magma", 120, 80, new List<MonsterSkill> { moltenPunch, flameThrower, explosion });

            return magma;
        }
    }
}
