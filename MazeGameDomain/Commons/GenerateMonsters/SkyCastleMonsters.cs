using MazeGameDomain.Commons.Skills;
using MazeGameDomain.Enums;
using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.GenerateMonsters
{
    public static class SkyCastleMonsters
    {
        public static SkyCastleMonsterParameter GenerateSkeletonArcher()
        {
            MonsterSkill darkArrow = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Dark Arrow", 10, (int)AttackType.Ranged, 0);
            MonsterSkill darkRegenerate = MonsterSkillsCreation.MonsterCustomUtilitySkill("Dark Regenerate", 10, 10, (int)AttributeType.HP);
            SkyCastleMonsterParameter skeletonArcher = new SkyCastleMonsterParameter("Skeleton Archer", 50, 0, new List<MonsterSkill> { darkArrow, darkRegenerate });

            return skeletonArcher;
        }

        public static SkyCastleMonsterParameter GenerateWindVulture()
        {
            MonsterSkill drillPeck = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Drill Peck", 30, (int)AttackType.Melee, 0);
            MonsterSkill gust = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Gust", 30, (int)AttackType.Magic, 10);
            SkyCastleMonsterParameter windVulture = new SkyCastleMonsterParameter("Wind Vulture", 70, 30, new List<MonsterSkill> { drillPeck, gust });

            return windVulture;
        }

        public static SkyCastleMonsterParameter GenerateGryphon()
        {
            MonsterSkill wingAttack = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Wing Attack", 30, (int)AttackType.Melee, 0);
            MonsterSkill whirlwind = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Whirlwind", 30, (int)AttackType.Magic, 10);
            MonsterSkill featherDance = MonsterSkillsCreation.MonsterCustomUtilitySkill("Feather Dance", 10, 10, (int)AttributeType.HP);
            SkyCastleMonsterParameter gryphon = new SkyCastleMonsterParameter("Gryphon", 150, 30, new List<MonsterSkill> { wingAttack, whirlwind, featherDance });

            return gryphon;
        }

        public static SkyCastleMonsterParameter GenerateCockatrice()
        {
            MonsterSkill drillPeck = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Drill Peck", 30, (int)AttackType.Melee, 0);
            MonsterSkill venomousTail = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Venomous Tail", 30, (int)AttackType.Melee, 0);
            MonsterSkill bulletSeed = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Bullet Seed", 20, (int)AttackType.Magic, 10);
            SkyCastleMonsterParameter cockatrice = new SkyCastleMonsterParameter("Cockatrice", 50, 30, new List<MonsterSkill> { drillPeck, venomousTail, bulletSeed });

            return cockatrice;
        }

        public static SkyCastleMonsterParameter GenerateCrazedWindWizard()
        {
            MonsterSkill windBlast = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Wind Blast", 10, (int)AttackType.Magic, 0);
            MonsterSkill tornado = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Tornado", 30, (int)AttackType.Magic, 20);
            MonsterSkill windRecovery = MonsterSkillsCreation.MonsterCustomUtilitySkill("Wind Recovery", 30, 10, (int)AttributeType.HP);
            SkyCastleMonsterParameter crazedWindWizard = new SkyCastleMonsterParameter("Crazed Wind Wizard", 80, 40, new List<MonsterSkill> { windBlast, tornado, windRecovery });

            return crazedWindWizard;
        }

        public static SkyCastleMonsterParameter GenerateCrazedWindDragon()
        {
            MonsterSkill imbuedWindClaw = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Imbued Wind Claw", 20, (int)AttackType.Magic, 0);
            MonsterSkill tornado = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Tornado", 30, (int)AttackType.Magic, 20);
            MonsterSkill concentratedWindBlast = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Concentrated Wind Blast", 50, (int)AttackType.Magic, 20);
            MonsterSkill scalesRecovery = MonsterSkillsCreation.MonsterCustomUtilitySkill("Scales Recovery", 30, 10, (int)AttributeType.HP);
            SkyCastleMonsterParameter crazedWindWizard = new SkyCastleMonsterParameter("Wind Dragon", 200, 60, new List<MonsterSkill> { imbuedWindClaw, tornado, scalesRecovery });

            return crazedWindWizard;
        }
    }
}
