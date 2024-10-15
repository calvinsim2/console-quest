using MazeGameDomain.Enums;
using MazeGameDomain.Models;
using MazeGameDomain.Models.Monsters;

namespace MazeGameDomain.Constants
{
    public static class InGameMessage
    {
        public static readonly string PressAnyKeyToContinue = "Press any key to continue...";
        public static readonly string BlankRow = string.Empty;
        public static readonly string PromptName = "Insert your Name:";
        public static readonly string ChooseClass = "Choose your desired Class....";
        public static readonly string Warrior = "Warrior - Warriors are adept in close combat, making them exceptional in compact and tight environments" +
            "\n In addition, warriors have higher constitution compared to their counterparts." +
            "\n However, their drawbacks are areas that are vast and wide, which makes them hard to attack opponents.";

        public static readonly string Magician = "Magician - Magicians are suited for combats in any environment." +
            "\n In addition, magicians have the capability to opt for specialisations (Fire / Ice) , which give them an advantage on some maps." +
            "\n However, magicians have lower constitution compared to their counterparts.";

        public static readonly string Archer = "Archer - Archer are adept in range combat, making them exceptional in wide and vast environments," +
            "\n they are able to engage their foes while keeping out of harms way." +
            "\n However, archers struggle in compact and tight environments.";

        public static readonly string PromptClassSelection = "Please select your desired class:" +
            "\n 1 - Warrior" +
            "\n 2 - Magician" +
            "\n 3 - Archer";

        public static readonly string InvalidClassSelection = "Invalid class selected, please input the correct selections:" +
            "\n 1 - Warrior" +
            "\n 2 - Magician" +
            "\n 3 - Archer";

        public static readonly string InvalidSpecialisationSelected = "Invalid Specialisation Selected.";

        public static readonly string PromptMagicianSpecialisation = "Select your Specialisation:" +
            "\n 1 - Ice Mage" +
            "\n 2 - Fire Mage";

        public static readonly string MagicianSpecialisationDescription = "Prior to leaving the town, an elder stops you for a quick chat" + 
            "\nAs a magician, you are eligible to specialise in either Fire or Ice magic, he has the capability to grant you such powers immediately";
        public static readonly string PromptCombatDecision = "Choose an action:" + "\n1 - Combat" + "\n2 - Items" + "\n8 - Read Current Status";
        public static readonly string InvalidCombatDecisionSelection = "Invalid decision selected, please input the correct decision.";
        public static readonly string PromptSkill = "Select a skill:";
        public static readonly string InvalidSkillOptionSelection = "Invalid skill option selected, please input the correct selection.";
        public static readonly string InsufficentManaSelection = "Insufficient mana, consume a potion or choose another attack.";
        public static readonly string BackMessage = "9 - Back";


        public static readonly string Town = "Welcome Adventurer, it seems like trouble are surfacing again in the dungeons, townsfolk are lamenting" + 
            "\non the fact that attacks on the town from monsters in the nearby dungeons are getting more frequent." + 
            "\nCan you be their hero, transverse and clear out those dungeons, and resolve these problems once and for all?";
        
        /// <summary>
        /// Message used for Ice Cavern Map
        /// </summary>
        public static readonly string IceCavern = "Entering: Ice Cavern........";
        public static readonly string IceResistant = "You are blessed with resistance to ice, proceeding to next dungeon....";
        public static readonly string NotIceResistant = "Unable to escape the cold, frozen cavern, you are forced to venture deeper into the cavern...";
        public static readonly string DefeatIceSlime = "The ice slime melts, you venture on further....";
        public static readonly string DefeatIceBoar = "The boar make multiple squeaking sounds and eventually falls, time to move on!";
        public static readonly string DefeatIceYeti = "Yeti releases a huge howl, and falls to its knees!";

        /// <summary>
        /// Message used for Death Flow
        /// </summary>
        public static readonly string Death = "Blood gushes out from your mouth, your vision turns blurry, and eventually blacked out. You Died.";
        /// <summary>
        /// Message used for Victory Flow
        /// </summary>
        public static readonly string Complete = "You successfully completed all the dungeons and melted the all foes that stands in your way!" + 
                    "\nAs you return to town triumphant, villagers celebrate your return and praises your bravery!" +
                    "\nCongratulations! Adventurer!";

        public static readonly string InvalidPathSelected = "Invalid Path selected, please input the correct Path.";
        
        public static readonly string AvoidedTrap = "You sucessfully avoided the trap!";

        public static void Introduction()
        {
            Console.WriteLine("Welcome to ConsoleQuest, an adventure game which is solely interactable via console app.");
            Console.WriteLine("Note: In non-decision situations, there won't be a prompt. Press ANY key to continue whenever an in-game message appears in the console app.");
        }
        public static string DisplayAdventurerSelectedSpecialisation(int specialisation)
        {
            return $"You have chosen to be a/an {(Specialisation)specialisation}";
        }
        public static string ReadCurrentStatus(Adventurer adventurer, Monster monster)
        {
            return $"Player - HP: {adventurer.Health}, MP: {adventurer.MP}, Class: {(Class)adventurer.Class}" +
                $"\nMonster {monster.Name} - HP: {monster.Health}, MP: {monster.MP}, Type: {monster.Type}";
        }
        public static string AdventurerSkillMessage(int index, string skillName, decimal mpCost, decimal damage)
        {
            return $"{index} - {skillName}, MP: {mpCost}, Damage: {damage}";
        }
        public static string AdventurerInsufficientMPSkillMessage(int index, string skillName, decimal mpCost, decimal damage)
        {
            return $"{index} - {skillName}, MP: {mpCost} (Not Enough Mana), Damage: {damage}";
        }

        public static string MonsterAttackingInformation(string monsterName, string skillName, decimal monsterDamage)
        {
            return $"{monsterName} uses {skillName}!" + $"\n dealing {monsterDamage} Damage!";
        }

        public static string AdventurerCurrentHealth(decimal currentHealth)
        {
            return $"Your current Health: {currentHealth}";
        }

        public static string AdventurerAttackingInformation(string skillName, decimal skillDamage)
        {
            return $"You used {skillName}!" + $"\n dealing {skillDamage} Damage!";
        }

        public static string MonsterCurrentHealth(decimal currentHealth, string monsterName)
        {
            return $"{monsterName} current Health: {currentHealth}";
        }

        public static string AdventurerUtilityInformation(string skillName, string attributeType, decimal skillDamage)
        {
            return $"You used {skillName}!" + $"\nyour {attributeType} is increased by {skillDamage}.";
        }

        public static string PromptForkRoadOptions(string option1, string option2)
        {
            return "Make your choice: " + $"\n1 - {option1}" + $"\n2 - {option2}";
        }

        public static string DisplayForkRoadDecisions(string option)
        {
            return $"You have chosen: {option}";
        }
        public static string DisplayCurrentTrapNavigation(int trapIndex)
        {
            return $"Weaving through trap{trapIndex}";
        }

        public static string DisplayUnableToAvoidTrapMessage(decimal damageTaken)
        {
            return $"You are unable to avoid the trap in time, it connects, and you took {damageTaken} damage.";
        }
    }
}
