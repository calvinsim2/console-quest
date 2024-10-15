using MazeGameDomain.Constants;
using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Combat
{
    public static class Combat
    {
        public static bool CommenceCombat(Adventurer adventurer, Monster monster)
        {
            bool adventurerVictorious = false;

            while (adventurer.Health > 0 && monster.Health > 0)
            {
                // if playerSkill is null, means item choice was selected, player do not attack for that turn.
                AdventurerSkill? adventurerSkill = PlayerInput(adventurer, monster);

                MonsterSkill monsterSkill = MonsterDecision(monster);

                EntitiesInteraction(adventurerSkill, monsterSkill, adventurer, monster);
                // player's health has higher priority, if player health reaches 0 first, considered player lose.

                if (adventurer.Health <= 0)
                {
                    adventurerVictorious = false;
                    break;
                }

                if (monster.Health <= 0)
                {
                    adventurerVictorious = true;
                    break;
                }
            }

            return adventurerVictorious;
        }

        public static void EntitiesInteraction(AdventurerSkill? adventurerSkill, MonsterSkill monsterSkill, 
                                               Adventurer adventurer, Monster monster)
        {
            // if playerskill is null, compute monster's attack only
            
            if (adventurerSkill is null)
            {
                if (monsterSkill.IsUtility)
                {
                    MonsterUtility(monsterSkill, monster);
                }
                else
                {
                    MonsterAttacks(monsterSkill, adventurer, monster);
                }
                
                return;
            }

            if (!adventurerSkill.IsUtility && !monsterSkill.IsUtility)
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 10);

                if (randomNumber > 3)
                {
                    PlayerAttacks(adventurerSkill, adventurer, monster);

                    if (monster.Health <= 0)
                    {
                        return;
                    }

                    MonsterAttacks(monsterSkill, adventurer, monster);

                }
                else
                {
                    MonsterAttacks(monsterSkill, adventurer, monster);

                    if (adventurer.Health <= 0)
                    {
                        return;
                    }

                    PlayerAttacks(adventurerSkill, adventurer, monster);

                }

                return;
            }

            if (!adventurerSkill.IsUtility)
            {
                MonsterUtility(monsterSkill, monster);
                PlayerAttacks(adventurerSkill, adventurer, monster);
            }
            else
            {
                PlayerUtility(adventurerSkill, adventurer);
                MonsterAttacks(monsterSkill, adventurer, monster);
            }
            
        }

        #region Monster and Player attacks / utility function

        public static void MonsterAttacks(MonsterSkill monsterSkill, Adventurer adventurer, Monster monster)
        {
            decimal monsterDamage = monsterSkill.EffectPower;
            decimal manaCost = monsterSkill.MpCost;

            Console.WriteLine(InGameMessage.MonsterAttackingInformation(monster.Name, monsterSkill.SkillName, monsterDamage));
            adventurer.DecreaseHealth(monsterDamage);
            Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurer.Health));
            Console.WriteLine(InGameMessage.BlankRow);
            monster.DecreaseMP(manaCost);
        }

        public static void PlayerAttacks(AdventurerSkill adventurerSkill, Adventurer adventurer, Monster monster)
        {
            decimal adventurerDamage = adventurerSkill.EffectPower;
            decimal manaCost = adventurerSkill.MpCost;

            Console.WriteLine(InGameMessage.AdventurerAttackingInformation(adventurerSkill.SkillName, adventurerDamage));
            monster.DecreaseHealth(adventurerDamage);
            Console.WriteLine(InGameMessage.MonsterCurrentHealth(monster.Health, monster.Name));
            Console.WriteLine(InGameMessage.BlankRow);
            adventurer.DecreaseMP(manaCost);
        }

        public static void MonsterUtility(MonsterSkill monsterSkill, Monster monster)
        {
            AttributeType attributetype = (AttributeType)monsterSkill.AttributeTarget;

            switch (attributetype)
            {
                case AttributeType.Health:
                    monster.IncreaseHealth(monsterSkill.EffectPower);
                    Console.WriteLine(InGameMessage.AdventurerUtilityInformation(monsterSkill.SkillName, nameof(attributetype), monsterSkill.EffectPower));
                    break;

                case AttributeType.MP:
                    monster.IncreaseMP(monsterSkill.EffectPower);
                    Console.WriteLine(InGameMessage.AdventurerUtilityInformation(monsterSkill.SkillName, nameof(attributetype), monsterSkill.EffectPower));
                    break;

                default: break;
            }
        }

        public static void PlayerUtility(AdventurerSkill adventurerSkill, Adventurer adventurer)
        {
            AttributeType attributetype = (AttributeType)adventurerSkill.AttributeTarget;

            switch(attributetype) 
            {
                case AttributeType.Health:
                    adventurer.IncreaseHealth(adventurerSkill.EffectPower);
                    Console.WriteLine(InGameMessage.AdventurerUtilityInformation(adventurerSkill.SkillName, attributetype.ToString(), adventurerSkill.EffectPower));
                    break;

                case AttributeType.MP:
                    adventurer.IncreaseMP(adventurerSkill.EffectPower);
                    Console.WriteLine(InGameMessage.AdventurerUtilityInformation(adventurerSkill.SkillName, attributetype.ToString(), adventurerSkill.EffectPower));
                    break;

                default: break;
            }
        }
        #endregion

        #region Monster Decision
        public static MonsterSkill MonsterDecision(Monster monster)
        {
            List<MonsterSkill> availableMonsterSkills = monster.MonsterSkills.Where(x => monster.MP >= x.MpCost).ToList(); 

            Random random = new Random();
            int randomChoice = random.Next(0, availableMonsterSkills.Count);

            return availableMonsterSkills[randomChoice];
        }
        #endregion

        #region Player Input Subroutine
        public static AdventurerSkill? PlayerInput(Adventurer adventurer, Monster monster)
        {
            AdventurerCombatDecision adventurerCombatDecision = new AdventurerCombatDecision();

            while (!adventurerCombatDecision.PlayerDecided)
            {
                Console.WriteLine(InGameMessage.PromptCombatDecision);
                string userInput = Console.ReadKey(intercept: true).KeyChar.ToString();

                if (!IsValidCombatDecision(userInput))
                {
                    Console.WriteLine(InGameMessage.InvalidCombatDecisionSelection);
                    Console.WriteLine(InGameMessage.BlankRow);
                    continue;
                }

                int userInputInt = int.Parse(userInput);

                if (userInputInt == CombatDecision.ReadStatus)
                {
                    ReadCurrentStatus(adventurer, monster);
                    continue;
                }

                if (userInputInt == CombatDecision.Combat)
                {
                    PlayerCombatInput(adventurer, adventurerCombatDecision);
                }
                else
                {
                    adventurerCombatDecision.SelectedAdventurerSkill = null;
                }

            }

            return adventurerCombatDecision.SelectedAdventurerSkill;
        }

        #region Player Combat Input Related
        public static void ReadCurrentStatus(Adventurer adventurer, Monster monster) 
        {
            Console.WriteLine(InGameMessage.BlankRow);
            Console.WriteLine(InGameMessage.ReadCurrentStatus(adventurer, monster));
            Console.WriteLine(InGameMessage.BlankRow);
        }
        public static void PlayerCombatInput(Adventurer adventurer, AdventurerCombatDecision adventurerCombatDecision)
        {
            Console.WriteLine(InGameMessage.PromptSkill);
            Console.WriteLine(InGameMessage.BlankRow);

            while (true)
            {
                DisplayPlayerSkills(adventurer.Skills, adventurer.MP);
                Console.WriteLine(InGameMessage.BackMessage);
                Console.WriteLine(InGameMessage.BlankRow);

                string userInput = Console.ReadKey(intercept: true).KeyChar.ToString();

                if (!IsValidSkillSelected(userInput, adventurer.Skills))
                {
                    continue;
                }

                int decision = int.Parse(userInput);

                if (decision == CombatDecision.Exit)
                {
                    adventurerCombatDecision.PlayerDecided = false;
                    adventurerCombatDecision.SelectedAdventurerSkill = null;
                    return;
                }

                if (!IsMPSufficientForSkill(decision, adventurer.Skills, adventurer.MP))
                {
                    continue;
                }

                adventurerCombatDecision.SelectedAdventurerSkill = GetPlayerSelectedSkill(decision, adventurer);
                adventurerCombatDecision.PlayerDecided = true;
                return;

            }
        }

        public static void DisplayPlayerSkills(IEnumerable<AdventurerSkill> skills, decimal adventurerMP)
        {
            List<AdventurerSkill> adventurerSkills = skills.ToList();

            for (int i = 0; i < adventurerSkills.Count; i++)
            {
                if (adventurerMP >= adventurerSkills[i].MpCost)
                {
                    Console.WriteLine(InGameMessage.AdventurerSkillMessage(i, adventurerSkills[i].SkillName, adventurerSkills[i].MpCost, adventurerSkills[i].EffectPower));
                }
                else
                {
                    Console.WriteLine(InGameMessage.AdventurerInsufficientMPSkillMessage(i, adventurerSkills[i].SkillName, adventurerSkills[i].MpCost, adventurerSkills[i].EffectPower));
                }
            }

        }

        public static bool IsValidCombatDecision(string userInput)
        {
            bool validParsing = int.TryParse(userInput, out int userCombatDecisionInput);

            if (!validParsing)
            {
                return false;
            }

            List<int> validCombatDecision = new List<int> { CombatDecision.Combat, CombatDecision.Items, CombatDecision.ReadStatus };

            bool IsValidCombatDecision = validCombatDecision.Contains(userCombatDecisionInput);

            if (validCombatDecision.Contains(userCombatDecisionInput))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool IsValidSkillSelected(string userInput, IEnumerable<AdventurerSkill> skills)
        {
            List<AdventurerSkill> adventurerSkills = skills.ToList();
            bool validParsing = int.TryParse(userInput, out int userSkillInput);

            if (!validParsing)
            {
                Console.WriteLine(InGameMessage.InvalidSkillOptionSelection);
                return false;
            }

            bool validSkill = (userSkillInput >= 0 && userSkillInput < adventurerSkills.Count) || userSkillInput == CombatDecision.Exit;

            if (!validSkill)
            {
                Console.WriteLine(InGameMessage.InvalidSkillOptionSelection);
                Console.WriteLine(InGameMessage.BlankRow);
                return false;
            }

            return true;

        }

        public static bool IsMPSufficientForSkill(int userInput, IEnumerable<AdventurerSkill> skills, decimal adventurerMP)
        {
            List<AdventurerSkill> adventurerSkills = skills.ToList();

            AdventurerSkill selectedSkill = adventurerSkills[userInput];

            if (adventurerMP < selectedSkill.MpCost)
            {
                Console.WriteLine(InGameMessage.InsufficentManaSelection);
                Console.WriteLine(InGameMessage.BlankRow);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static AdventurerSkill GetPlayerSelectedSkill(int userInput, Adventurer adventurer)
        {
            List<AdventurerSkill> adventurerSkills = adventurer.Skills.ToList();

            return adventurerSkills[userInput];
        }

        #endregion

        #region Player Item Input Related
        public static void PlayerItemInput(Adventurer adventurer, AdventurerCombatDecision adventurerCombatDecision)
        {

        }
        #endregion

        #endregion
    }
}
