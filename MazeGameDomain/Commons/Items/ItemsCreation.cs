using MazeGameDomain.Builders;
using MazeGameDomain.Constants;
using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons.Items
{
    public static class ItemsCreation
    {
        public static Item CreateHpPotion()
        {
            return new ItemBuilder().SetName(InGameMessage.HpPotion)
                                    .SetDescription(InGameMessage.HpPotionDescription)
                                    .SetItemNumber((int)ItemIndex.HpPotion)
                                    .SetAttributeTarget((int)AttributeType.HP)
                                    .SetEffectPower(50).GetItem();
        }

        public static Item CreateMpPotion()
        {
            return new ItemBuilder().SetName(InGameMessage.MpPotion)
                                    .SetDescription(InGameMessage.MpPotionDescription)
                                    .SetItemNumber((int)ItemIndex.MpPotion)
                                    .SetAttributeTarget((int)AttributeType.MP)
                                    .SetEffectPower(50).GetItem();
        }

        public static Item CreateHpElixir()
        {
            return new ItemBuilder().SetName(InGameMessage.HpElixir)
                                    .SetDescription(InGameMessage.HpElixirDescription)
                                    .SetItemNumber((int)ItemIndex.HpElixir)
                                    .SetAttributeTarget((int)AttributeType.HP)
                                    .SetEffectPower(100).GetItem();
        }

        public static Item CreateMpElixir()
        {
            return new ItemBuilder().SetName(InGameMessage.MpElixir)
                                    .SetDescription(InGameMessage.MpElixirDescription)
                                    .SetItemNumber((int)ItemIndex.MpElixir)
                                    .SetAttributeTarget((int)AttributeType.MP)
                                    .SetEffectPower(100).GetItem();
        }
    }
}
