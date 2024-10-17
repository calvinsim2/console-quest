using MazeGameDomain.Commons.Skills;
using MazeGameDomain.Enums;
using MazeGameDomain.ModelParameters;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.GenerateMonsters
{
    public static class ThickForestMonsters
    {
        public static ThickForestMonsterParameter GenerateTreeStump()
        {
            MonsterSkill tackle = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Tackle", 10, (int)AttackType.Melee, 0);
            MonsterSkill entanglingRoot = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Entangling Root", 20, (int)AttackType.Magic, 10);
            ThickForestMonsterParameter treeStump = new ThickForestMonsterParameter("Tree Stump", 50, 10, new List<MonsterSkill> { tackle, entanglingRoot });

            return treeStump;
        }

        public static ThickForestMonsterParameter GenerateWildMonkey()
        {
            MonsterSkill tailSmash = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Tail Smash", 10, (int)AttackType.Melee, 0);
            MonsterSkill enchantedBananaSkinToss = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Enchanted Banana Skin Toss", 30, (int)AttackType.Magic, 10);
            ThickForestMonsterParameter wildMonkey = new ThickForestMonsterParameter("Wild Monkey", 70, 20, new List<MonsterSkill> { tailSmash, enchantedBananaSkinToss });

            return wildMonkey;
        }

        public static ThickForestMonsterParameter GenerateForestBandit()
        {
            MonsterSkill daggerStab = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Dagger Stab", 20, (int)AttackType.Melee, 0);
            MonsterSkill rockThrow = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Rock Throw", 40, (int)AttackType.Ranged, 10);
            MonsterSkill wildHerbs = MonsterSkillsCreation.MonsterCustomUtilitySkill("Wild Herbs", 20, 10, (int)AttributeType.HP);
            ThickForestMonsterParameter forestBandit = new ThickForestMonsterParameter("Forest Bandit", 80, 50, new List<MonsterSkill> { daggerStab, rockThrow, wildHerbs });

            return forestBandit;
        }

        public static ThickForestMonsterParameter GenerateOneEyeLizard()
        {
            MonsterSkill tailSmash = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Tail Smash", 10, (int)AttackType.Melee, 0);
            MonsterSkill bodySlam = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Body Slam", 30, (int)AttackType.Melee, 0);
            MonsterSkill tailRestoration = MonsterSkillsCreation.MonsterCustomUtilitySkill("Tail Restoration", 20, 10, (int)AttributeType.HP);
            ThickForestMonsterParameter oneEyeLizard = new ThickForestMonsterParameter("One Eye Lizard", 70, 20, new List<MonsterSkill> { tailSmash, bodySlam });

            return oneEyeLizard;
        }

        public static ThickForestMonsterParameter GenerateForestGoblin()
        {
            MonsterSkill goblinPunch = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Goblin Punch", 20, (int)AttackType.Melee, 0);
            MonsterSkill defeaningHowl = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Defeaning Howl", 30, (int)AttackType.Magic, 0);
            ThickForestMonsterParameter forestGoblin = new ThickForestMonsterParameter("Forest Goblin", 80, 20, new List<MonsterSkill> { goblinPunch, defeaningHowl });

            return forestGoblin;
        }

        public static ThickForestMonsterParameter GenerateGiantEarthWolf()
        {
            MonsterSkill takeDown = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Take Down", 20, (int)AttackType.Melee, 0);
            MonsterSkill defeaningHowl = MonsterSkillsCreation.MonsterCustomOffensiveSkill("Earthly Jaws", 40, (int)AttackType.Magic, 20);
            MonsterSkill earthlyRegeneration = MonsterSkillsCreation.MonsterCustomUtilitySkill("Earthly Regeneration", 30, 10, (int)AttributeType.HP);
            ThickForestMonsterParameter forestGoblin = new ThickForestMonsterParameter("Giant Earth Wolf", 120, 60, new List<MonsterSkill> { takeDown, defeaningHowl, earthlyRegeneration });

            return forestGoblin;
        }
    }
}
