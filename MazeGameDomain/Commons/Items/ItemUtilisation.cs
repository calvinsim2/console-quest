using MazeGameDomain.Constants;
using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Items
{
    public static class ItemUtilisation
    {
        
        public static void PlayerItemInput(Adventurer adventurer, AdventurerCombatDecision adventurerCombatDecision)
        {
            Console.WriteLine(InGameMessage.PromptItem);
            Console.WriteLine(InGameMessage.BlankRow);

            while (true)
            {
                DisplayAvailableItems(adventurer.Inventory);
                Console.WriteLine(InGameMessage.BackMessage);
                Console.WriteLine(InGameMessage.BlankRow);

                string userInput = Console.ReadKey(intercept: true).KeyChar.ToString();

                if (!IsValidItemSelected(userInput, adventurer.Inventory))
                {
                    continue;
                }

                int decision = int.Parse(userInput);

                if (decision == CombatDecision.Exit)
                {
                    adventurerCombatDecision.PlayerDecided = false;
                    return;
                }

                UtiliseSelectedItem(decision, adventurer);
                adventurerCombatDecision.PlayerDecided = true;
                return;

            }
        }

        public static void DisplayAvailableItems(Dictionary<int, int> inventory)
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine(InGameMessage.InventoryEmpty);
                Console.WriteLine(InGameMessage.BlankRow);
                return;
            }

            foreach (KeyValuePair<int, int> indexItemPair in inventory)
            {
                Item item = ItemDetails.ItemIndexAndItemPairs[indexItemPair.Key];
                Console.WriteLine(InGameMessage.DisplayAdventurerCurrentItems(item.ItemNo, item.Name, item.Description, indexItemPair.Value));
            }
        }

        public static bool IsValidItemSelected(string userInput, Dictionary<int, int> inventory)
        {
            bool validParsing = int.TryParse(userInput, out int userItemInput);

            if (!validParsing)
            {
                Console.WriteLine(InGameMessage.InvalidItemOptionSelected);
                return false;
            }

            bool isValidItemOption = inventory.ContainsKey(userItemInput) || userItemInput == CombatDecision.Exit;

            if (!isValidItemOption)
            {
                Console.WriteLine(InGameMessage.InvalidItemOptionSelected);
                Console.WriteLine(InGameMessage.BlankRow);
                return false;
            }

            return true;

        }

        public static void UtiliseSelectedItem(int selectedItemNo, Adventurer adventurer)
        {
            Item selectedItem = ItemDetails.GetItemByItemNumber(selectedItemNo);
            ItemEffect(selectedItemNo, adventurer);
            // deduct or remove item from adventurer inventory.
            UpdateAdventurerInventory(selectedItemNo, adventurer, -1);

        }

        private static void ItemEffect(int selectedItemNo, Adventurer adventurer)
        {
            Item selectedItem = ItemDetails.GetItemByItemNumber(selectedItemNo);
            AttributeType attributetype = (AttributeType)selectedItem.AttributeTarget;

            switch (attributetype)
            {
                case AttributeType.HP:
                    adventurer.IncreaseHealth(selectedItem.EffectPower);
                    Console.WriteLine(InGameMessage.ItemEffectInformation(selectedItem.Name, attributetype.ToString(), selectedItem.EffectPower));
                    Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurer.Health));
                    break;

                case AttributeType.MP:
                    adventurer.IncreaseMP(selectedItem.EffectPower);
                    Console.WriteLine(InGameMessage.ItemEffectInformation(selectedItem.Name, attributetype.ToString(), selectedItem.EffectPower));
                    Console.WriteLine(InGameMessage.AdventurerCurrentMP(adventurer.MP));
                    break;

                default: break;
            }
        }

        public static void UpdateAdventurerInventory(int selectedItemNo, Adventurer adventurer, int amountChange)
        {
            Dictionary<int, int> adventurerInventory = adventurer.Inventory;

            adventurerInventory[selectedItemNo] += amountChange; 

            if (adventurerInventory[selectedItemNo] <= 0)
            {
                adventurerInventory.Remove(selectedItemNo);
            }

        }
    }
}
