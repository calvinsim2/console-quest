using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Constants
{
    public static class InGameMessage
    {
        public static readonly string GameName = "ConsoleQuest";
        public static readonly string GameOver = "GameOver";

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

        /// <summary>
        /// Item Name
        /// </summary>
        public static readonly string HpPotion = "Health Potion";
        public static readonly string MpPotion = "Mana Potion";
        public static readonly string HpElixir = "Health Elixir";
        public static readonly string MpElixir = "Mana Elixir";

        /// <summary>
        /// Item Description
        /// </summary>
        public static readonly string HpPotionDescription = "Basic Health Potion, restores 50 HP on use.";
        public static readonly string MpPotionDescription = "Basic Mana Potion, restores 50 MP on use.";
        public static readonly string HpElixirDescription = "Premium Health Elixir, restores 100 HP on use.";
        public static readonly string MpElixirDescription = "Basic Mana Potion, restores 100 MP on use.";


        public static readonly string PromptCombatDecision = "Choose an action:" + "\n1 - Combat" + "\n2 - Items" + "\n8 - Read Current Status";
        public static readonly string InvalidCombatDecisionSelection = "Invalid decision selected, please input the correct decision.";
        public static readonly string PromptSkill = "Select a skill:";
        public static readonly string InvalidSkillOptionSelection = "Invalid skill option selected, please input the correct selection.";
        public static readonly string InsufficentManaSelection = "Insufficient mana, consume a potion or choose another attack.";
        public static readonly string PromptItem = "Choose an item:";
        public static readonly string BackMessage = "9 - Back";
        public static readonly string InventoryEmpty = "--- Your inventory is empty. ---";
        public static readonly string InvalidItemOptionSelected = "Invalid item option selected, please input the correct selection.";


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
        public static readonly string DefeatIceBoar = "The boar make multiple squeaking sounds and eventually falls, oddly, it starts melting...";
        public static readonly string DefeatIceYeti = "Yeti releases a huge howl, and falls to its knees!";

        /// <summary>
        /// Message used for Fire Cavern Map
        /// </summary>
        public static readonly string FireCavern = "Entering: Fire Cavern........";
        public static readonly string FireResistant = "You are blessed with resistance to fire, proceeding to next dungeon....";
        public static readonly string NotFireResistant = "Unable to resist the hot climate in this place, you are forced to venture deeper into the cavern...";
        public static readonly string DefeatFireSlime = "The fire slime turns into ashes, you venture on further....";
        public static readonly string DefeatFireBoar = "The boar falls, with flames on its back extinguished...";
        public static readonly string DefeatInfernal = "The flames that seem to power the infernal extinguishes, and it starts to crumble!";
        public static readonly string DefeatFireDragon = "The gargantuan dragon falls flat on its belly, and remain motionless...";
        public static readonly string DefeatLavaMorphling = "The Lava Morphling loses its shape, and plunged back into the Lava Lake!";
        public static readonly string DefeatMagma = "The Magma dissolves into the lake, and the lake returned to its calm state!";

        /// <summary>
        /// Message used for Thick Forest Map
        /// </summary>
        public static readonly string ThickForest = "Entering: Thick Forest... keep your eyes open! This place is cramped with trees and bushes within near vicinity of one another...";
        public static readonly string DefeatTreeStump = "The stump loses its moisture, and implants back itself into the soil.";
        public static readonly string DefeatWildMonkey = "The wild monkey lets out a crazed, hysterical laughter, and it loosens the grip on a branch and collapsed.";
        public static readonly string DefeatForestBandit = "The Bandit collapsed to the ground, strangely, it dissolves into the air, it seems like this bandit is summoned by magic.";
        public static readonly string DefeatOneEyeLizard = "The One Eyed Lizard closes his eye, yes, one single eye, and layed motionless.";
        public static readonly string DefeatForestGoblin = "The goblin lets out a huge groan, and shut its eyes, boring... you ignore it and moved on.";
        public static readonly string DefeatGiantEarthWolf = "Eventually, this huge wolf lets out a howl, albeit his final one, and thuds to the ground. " + 
                                                             "With the defeat of the wolf, you sense that the forest has a sudden soothing aura in it.";
        public static readonly string EarthDietySpeech = "Greetings Adventurer, on the journey to destroy monsters in the dungeons aren't you? Please be careful.... " + 
                                                         "I've seen many adventurers of your kind losing their lives doing the same thing as well! " + 
                                                         "Here, perhaps this will help you with your journey...";
        public static readonly string EarthDietyRestoration = "The Earth Diety chants for a moment, you'll discover that your health and mana have been replenished slightly!";

        /// <summary>
        /// Message used for Sky Castle Map
        /// </summary>
        public static readonly string SkyCastle = "Entering: Sky Castle... this wide and open land once used to be a prosperous kingdom, only to be reduced to this state... " + 
                                                  "Nevertheless, be wary! The traps and defense in this map are still active, and monsters have made this place their new home!";

        public static readonly string DefeatSkeletonArcher = "The skeleton archer's bone starts collapsing like dominos.";
        public static readonly string DefeatWindVulture = "Squawk! goes the vulture, and the next thing you know, it dive towards the forest with a loud thud sound" + 
                                                             " never to be seen again.";
        public static readonly string DefeatGryphon = "The gargantuan gryphon falls, causing the grounds in the castle to tremble slightly.";
        public static readonly string DefeatCockatrice = "With this weird creature falling, you witness the chicken body and snake tail detach from each other, and they lay motionless";
        public static readonly string DefeatCrazedOldWizard = "Putting this old man out of his misery is the best you could do for him - rest in peace, old man.";
        public static readonly string DefeatWindDragon = "The mighty wind dragon falls, you feel the wind in the castle died down.";

        /// <summary>
        /// Message used for Death Flow
        /// </summary>
        public static readonly string Death = "Blood gushes out from your mouth, your vision turns blurry, and eventually blacked out. You died... " + 
                                              "without any brave Adventurer protecting the Town, monsters soon overrun and destroyed the Town." + 
                                              "Better Luck Next Time!";
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

        public static string DisplayLearntNewSkillMessage(AdventurerSkill adventurerSkill)
        {
            string learntSkillMessage = !adventurerSkill.IsUtility ? 
                    $"New Skill Acquired - {adventurerSkill.SkillName}, Damage: {adventurerSkill.EffectPower}, MP Cost: {adventurerSkill.MpCost}, AttackType: {((AttackType)adventurerSkill.AttackType).ToString()}" 
                    : $"New Skill Acquired - {adventurerSkill.SkillName}, MP Cost: {adventurerSkill.MpCost}, Attribute: {adventurerSkill.AttributeTarget}, Amount Restore: {adventurerSkill.EffectPower}";

            return learntSkillMessage;

        }
        public static string ReadCurrentStatus(Adventurer adventurer, Monster monster, int mapType)
        {
            return $"Player: {adventurer.Name} - HP: {adventurer.Health}, MP: {adventurer.MP}, Class: {((Class)adventurer.Class).ToString()}" +
                $"\nMonster: {monster.Name} - HP: {monster.Health}, MP: {monster.MP}, Type: {((ElementType)monster.Type).ToString()}" + 
                $"\nCurrent Map Type: {((MapType)mapType).ToString()}" + 
                "\n" +
                "\nTight Maps - Ranged attacks has 25% chance of missing, 75% to deal 1/2 damage." +
                "\nWide Maps - Melee attacks has 25% chance of missing, 75% to deal 1/2 damage.";
        }
        public static string AdventurerSkillMessage(int index, string skillName, decimal mpCost, decimal damage, int attackType)
        {
            return $"{index} - {skillName}, MP: {mpCost}, Damage: {damage}, Type: {((AttackType)attackType).ToString()}";
        }
        public static string AdventurerInsufficientMPSkillMessage(int index, string skillName, decimal mpCost, decimal damage, int attackType)
        {
            return $"{index} - {skillName}, MP: {mpCost} (Not Enough Mana), Damage: {damage}, Type: {((AttackType)attackType).ToString()}";
        }

        public static string DisplayAdventurerCurrentItems(int itemIndex, string itemName, string itemDescription, int quantity)
        {
            return $"{itemIndex} - {itemName}: {itemDescription}\t Quantity: {quantity}";
        }

        public static string ItemEffectInformation(string itemName, string attributeType, decimal effectPower)
        {
            return $"You consumed a {itemName}, your {attributeType} is increased by {effectPower}.";
        }

        public static string ObtainedItemInformation(string itemName, int quantity) 
        {
            return $"You've acquired {itemName}: {quantity}";
        }
        public static string MonsterAttackingInformation(string monsterName, string skillName, decimal monsterDamage)
        {
            return $"{monsterName} uses {skillName}! Dealing {monsterDamage} Damage!";
        }

        public static string AdventurerCurrentHealth(decimal currentHealth)
        {
            return $"Your current Health: {currentHealth}";
        }

        public static string AdventurerCurrentMP(decimal currentMP)
        {
            return $"Your current MP: {currentMP}";
        }

        public static string AttackMissDueToMapTypeMismatch()
        {
            return "Attack missed due to incompatible attack type!";
        }

        public static string AttackDamageNerfedDueToMapTypeMismatch()
        {
            return "Incompatibile attack type, damage dealt is halved.";
        }

        public static string AdventurerAttackingInformation(string skillName, decimal skillDamage)
        {
            return $"You used {skillName}! Dealing {skillDamage} Damage!";
        }

        public static string MonsterCurrentHealth(decimal currentHealth, string monsterName)
        {
            return $"{monsterName} current Health: {currentHealth}";
        }

        public static string AdventurerUtilityInformation(string skillName, string attributeType, decimal effectPower)
        {
            return $"You used {skillName}!" + $"\nyour {attributeType} is increased by {effectPower}.";
        }

        public static string MonsterUtilityInformation(string skillName, string monsterName, string attributeType, decimal effectPower)
        {
            return $"{monsterName} used {skillName}!" + $"\n{monsterName} {attributeType} is increased by {effectPower}.";
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
