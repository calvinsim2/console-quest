using MazeGameDomain.Constants;
using MazeGameDomain.Models;
using MazeGameDomain.Models.Monsters;

namespace MazeGameDomain.Commons.Combat
{
    public static class Combat
    {
        //public static bool CommenceCombat(Adventurer adventurer, Monster monster)
        //{
        //    while (adventurer.Health > 0 && monster.Health > 0)
        //    {
        //        // if playerSkill is null, means item choice was selected, player do not attack for that turn.
        //        AdventurerSkill? playerSkill = PlayerInput(adventurer);


        //    }
        //}

        //public static MonsterSkill MonsterDecision(Monster monster)
        //{

        //}

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

                string userInput = Console.ReadLine();

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
