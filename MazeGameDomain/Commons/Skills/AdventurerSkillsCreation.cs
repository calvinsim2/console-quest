using MazeGameDomain.Builders;
using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Skills
{
    public static class AdventurerSkillsCreation
    {
        public static AdventurerSkill AdventurerCustomOffensiveSkill(string skillName, decimal effectPower, int attackType, decimal mpCost)
        {
            return new AdventurerSkillBuilder().SetName(skillName).SetEffectPower(effectPower).SetAttackType(attackType).SetMpCost(mpCost).Build();
        }

        public static AdventurerSkill AdventurerCustomUtilitySkill(string skillName, decimal effectPower, decimal mpCost, int attributeTarget)
        {
            return new AdventurerSkillBuilder().SetName(skillName).SetEffectPower(effectPower).SetMpCost(mpCost).SetIsUtility(true).SetAttributeTarget(attributeTarget).Build();
        }

        public static ICollection<AdventurerSkill> WarriorDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill powerStrike = new AdventurerSkillBuilder().SetName("Power Strike").SetEffectPower(10m).SetAttackType((int)AttackType.Melee).SetMpCost(0m).Build();
            AdventurerSkill advancedBrandish = new AdventurerSkillBuilder().SetName("Advanced Brandish").SetEffectPower(30m).SetAttackType((int)AttackType.Melee).SetMpCost(10m).Build();
            AdventurerSkill mpRestore = new AdventurerSkillBuilder().SetName("MP Restore").SetEffectPower(30m).SetMpCost(0m).SetIsUtility(true).SetAttributeTarget(2).Build();
            defaultSkills.Add(powerStrike);
            defaultSkills.Add(advancedBrandish);
            defaultSkills.Add(mpRestore);

            return defaultSkills;
        }

        public static ICollection<AdventurerSkill> MagicianDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill magicClaw = new AdventurerSkillBuilder().SetName("Magic Claw").SetEffectPower(10m).SetAttackType((int)AttackType.Magic).SetMpCost(0m).Build();
            AdventurerSkill quantumExplosion = new AdventurerSkillBuilder().SetName("Quantum Explosion").SetEffectPower(30m).SetAttackType((int)AttackType.Magic).SetMpCost(30m).Build();
            defaultSkills.Add(magicClaw);
            defaultSkills.Add(quantumExplosion);

            return defaultSkills;
        }

        public static ICollection<AdventurerSkill> BowmanDefaultSkills()
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();

            AdventurerSkill bowSmash = new AdventurerSkillBuilder().SetName("Bow Smash").SetEffectPower(10m).SetAttackType((int)AttackType.Melee).SetMpCost(0m).Build();
            AdventurerSkill quickShot = new AdventurerSkillBuilder().SetName("Quick Shot").SetEffectPower(20m).SetAttackType((int)AttackType.Ranged).SetMpCost(0m).Build();
            AdventurerSkill chargedShot = new AdventurerSkillBuilder().SetName("Charged Shot").SetEffectPower(30m).SetAttackType((int)AttackType.Ranged).SetMpCost(10m).Build();
            defaultSkills.Add(bowSmash);
            defaultSkills.Add(quickShot);
            defaultSkills.Add(chargedShot);

            return defaultSkills;
        }

        /// <summary>
        /// Description: Creation of Warrior Skills
        /// </summary>
        public static AdventurerSkill PunishingSwing()
        {
            return new AdventurerSkillBuilder().SetName("Punishing Swing").SetEffectPower(30m).SetAttackType((int)AttackType.Magic).SetMpCost(30m).Build();
        }

        /// <summary>
        /// Description: Creation of Magician Skills
        /// </summary>
        public static AdventurerSkill ColdBeam()
        {
            return new AdventurerSkillBuilder().SetName("Cold Beam").SetEffectPower(20m).SetAttackType((int)AttackType.Magic).SetMpCost(20m).Build();
        }

        public static AdventurerSkill IceStrike()
        {
            return new AdventurerSkillBuilder().SetName("Ice Strike").SetEffectPower(40m).SetAttackType((int)AttackType.Magic).SetMpCost(40m).Build();
        }

        public static AdventurerSkill FlameExplosion()
        {
            return new AdventurerSkillBuilder().SetName("Flame Explosion").SetEffectPower(40m).SetAttackType((int)AttackType.Magic).SetMpCost(40m).Build();
        }

        public static AdventurerSkill FireArrow()
        {
            return new AdventurerSkillBuilder().SetName("Fire Arrow").SetEffectPower(20m).SetAttackType((int)AttackType.Magic).SetMpCost(20m).Build();
        }

        /// <summary>
        /// Description: Creation of Archer Skills
        /// </summary>
        public static AdventurerSkill ArrowRain()
        {
            return new AdventurerSkillBuilder().SetName("Arrow Rain").SetEffectPower(40m).SetAttackType((int)AttackType.Magic).SetMpCost(30m).Build();
        }
    }
}
