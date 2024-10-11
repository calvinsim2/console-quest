using MazeGameDomain.Constants;
using MazeGameDomain.Models;
using MazeGameDomain.Models.Monsters;

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
                AdventurerSkill? adventurerSkill = PlayerInput(adventurer);

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
            // else, rng to decide who attack first.
            // deduct each entities health and mana respectively.
            
            if (adventurerSkill is null)
            {
                MonsterAttacks(monsterSkill, adventurer, monster);
                return;
            }

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
        }

        public static void MonsterAttacks(MonsterSkill monsterSkill, Adventurer adventurer, Monster monster)
        {
            decimal monsterDamage = monsterSkill.Damage;
            decimal manaCost = monsterSkill.MpCost;

            Console.WriteLine(InGameMessage.MonsterAttackingInformation(monster.Name, monsterSkill.SkillName, monsterDamage));
            adventurer.DecreaseHealth(monsterDamage);
            Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurer.Health));
            Console.WriteLine(InGameMessage.BlankRow);
            monster.DecreaseMP(manaCost);
        }

        public static void PlayerAttacks(AdventurerSkill adventurerSkill, Adventurer adventurer, Monster monster)
        {
            decimal adventurerDamage = adventurerSkill.Damage;
            decimal manaCost = adventurerSkill.MpCost;

            Console.WriteLine(InGameMessage.AdventurerAttackingInformation(adventurerSkill.SkillName, adventurerDamage));
            monster.DecreaseHealth(adventurerDamage);
            Console.WriteLine(InGameMessage.MonsterCurrentHealth(adventurer.Health, monster.Name));
            Console.WriteLine(InGameMessage.BlankRow);
            adventurer.DecreaseMP(manaCost);
        }

        public static MonsterSkill MonsterDecision(Monster monster)
        {
            List<MonsterSkill> availableMonsterSkills = monster.MonsterSkills.Where(x => monster.MP >= x.MpCost).ToList(); 

            Random random = new Random();
            int randomChoice = random.Next(0, availableMonsterSkills.Count - 1);

            return availableMonsterSkills[randomChoice];
        }

        public static AdventurerSkill? PlayerInput(Adventurer adventurer)
        {
            AdventurerCombatDecision adventurerCombatDecision = new AdventurerCombatDecision();

            while (!adventurerCombatDecision.PlayerDecided)
            {
                Console.WriteLine(InGameMessage.PromptCombatDecision);
                string? userInput = Console.ReadLine();

                bool isValidCombatDecision = int.TryParse(userInput, out int userInputInt);
                if (!isValidCombatDecision)
                {
                    Console.WriteLine(InGameMessage.InvalidCombatDecisionSelection);
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

        public static void PlayerCombatInput(Adventurer adventurer, AdventurerCombatDecision adventurerCombatDecision)
        {
            Console.WriteLine(InGameMessage.PromptSkill);
            Console.WriteLine(InGameMessage.BlankRow);

            while (true)
            {
                DisplayPlayerSkills(adventurer.Skills, adventurer.MP);
                Console.WriteLine(InGameMessage.BlankRow);

                string? userInput = Console.ReadLine();

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

                if (IsMPSufficientForSkill(decision, adventurer.Skills, adventurer.MP))
                {
                    continue;
                }

                adventurerCombatDecision.SelectedAdventurerSkill = GetPlayerSelectedSkill(decision, adventurer);
                adventurerCombatDecision.PlayerDecided = true;

            }
        }

        public static void DisplayPlayerSkills(IEnumerable<AdventurerSkill> skills, decimal adventurerMP)
        {
            List<AdventurerSkill> adventurerSkills = skills.ToList();

            for (int i = 0; i < adventurerSkills.Count; i++)
            {
                if (adventurerMP > adventurerSkills[i].MpCost)
                {
                    Console.WriteLine(InGameMessage.AdventurerSkillMessage(i, adventurerSkills[i].SkillName, adventurerSkills[i].MpCost, adventurerSkills[i].Damage));
                }
                else
                {
                    Console.WriteLine(InGameMessage.AdventurerInsufficientMPSkillMessage(i, adventurerSkills[i].SkillName, adventurerSkills[i].MpCost, adventurerSkills[i].Damage));
                }
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
    }
}
