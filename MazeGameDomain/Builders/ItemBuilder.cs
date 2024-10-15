using MazeGameDomain.Models;

namespace MazeGameDomain.Builders
{
    public class ItemBuilder 
    {
        protected Item item = new Item();

        public ItemBuilder SetName(string itemName)
        {
            item.Name = itemName;
            return this;
        }

        public ItemBuilder SetDescription(string itemDescription)
        {
            item.Description = itemDescription;
            return this;
        }

        public ItemBuilder SetItemNumber(int itemNo)
        {
            item.ItemNo = itemNo;
            return this;
        }

        public ItemBuilder SetAttributeTarget(int attributeTarget)
        {
            item.AttributeTarget = attributeTarget;
            return this;
        }

        public ItemBuilder SetEffectPower(int effectPower)
        {
            item.EffectPower = effectPower;
            return this;
        }

        public Item GetItem()
        {
            return item;
        }
    }
}
