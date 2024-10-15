using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Items
{
    public static class ItemDetails
    {
        public static Dictionary<int, Item> ItemIndexAndItemPairs = new Dictionary<int, Item> 
        {
            { (int)ItemIndex.HpPotion, ItemsCreation.CreateHpPotion() },
            { (int)ItemIndex.MpPotion, ItemsCreation.CreateMpPotion() },
            { (int)ItemIndex.HpElixir, ItemsCreation.CreateHpElixir() },
            { (int)ItemIndex.MpElixir, ItemsCreation.CreateMpElixir() },
        };

        public static Item GetItemByItemNumber(int itemNo)
        {
            return ItemIndexAndItemPairs[itemNo];
        }
    }
}
