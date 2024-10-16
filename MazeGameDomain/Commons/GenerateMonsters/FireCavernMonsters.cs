using MazeGameDomain.Commons.Skills;
using MazeGameDomain.Enums;
using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.GenerateMonsters
{
    public static class FireCavernMonsters
    {
        public static FireCavernMonsterParameter GenerateFireSlime()
        {
            MonsterSkill flameSludge = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Flame Sludge", 10, (int)AttackType.Ranged, 0);
            FireCavernMonsterParameter fireSlime = new FireCavernMonsterParameter("Fire Slime", 30, 0, new List<MonsterSkill> { flameSludge });

            return fireSlime;
        }

        public static FireCavernMonsterParameter GenerateFireBoar()
        {
            MonsterSkill burningCharge = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Burning Charge", 10, (int)AttackType.Melee, 0);
            MonsterSkill flameTuskImpale = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Flame Tusk Impale", 20, (int)AttackType.Melee, 10);
            FireCavernMonsterParameter fireBoar = new FireCavernMonsterParameter("Fire Boar", 50, 20, new List<MonsterSkill> { burningCharge, flameTuskImpale });

            return fireBoar;
        }

        public static FireCavernMonsterParameter GenerateInfernal()
        {
            MonsterSkill flamingFist = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Flaming Fist", 20, (int)AttackType.Melee, 0);
            FireCavernMonsterParameter infernal = new FireCavernMonsterParameter("Infernal", 120, 0, new List<MonsterSkill> { flamingFist });

            return infernal;
        }

        public static FireCavernMonsterParameter GenerateFireDragon()
        {
            MonsterSkill wingAttack = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Wing Attack", 10, (int)AttackType.Melee, 0);
            MonsterSkill burningClaw = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Burning Claw", 20, (int)AttackType.Melee, 20);
            MonsterSkill fireBlast = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Fire Blast", 40, (int)AttackType.Magic, 80);
            FireCavernMonsterParameter fireDragon = new FireCavernMonsterParameter("Fire Dragon", 170, 60, new List<MonsterSkill> { wingAttack, burningClaw, fireBlast });

            return fireDragon;
        }

        public static FireCavernMonsterParameter GenerateLavaMorphling()
        {
            MonsterSkill lavaToss = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Lava Toss", 10, (int)AttackType.Magic, 0);
            MonsterSkill lavaWaveform = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Lava Waveform", 20, (int)AttackType.Magic, 10);
            FireCavernMonsterParameter lavaMorphling = new FireCavernMonsterParameter("Lava Morphling", 70, 20, new List<MonsterSkill> { lavaToss, lavaWaveform });

            return lavaMorphling;
        }

        public static FireCavernMonsterParameter GenerateMagma()
        {
            MonsterSkill moltenPunch = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Molten Punch", 10, (int)AttackType.Melee, 0);
            MonsterSkill flameThrower = MonsterSkillsCreation.MonsterCustomOffensiveSkill("FlameThrower", 20, (int)AttackType.Magic, 20);
            MonsterSkill explosion = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Explosion", 40, (int)AttackType.Melee, 30);
            FireCavernMonsterParameter magma = new FireCavernMonsterParameter("Magma", 120, 80, new List<MonsterSkill> { moltenPunch, flameThrower, explosion });

            return magma;
        }
    }
}
