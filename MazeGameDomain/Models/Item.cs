namespace MazeGameDomain.Models
{
    /// <summary>
    /// Instantiates an object for adventurer to utilise during combat.
    /// </summary>
    /// <param name="Name">The name of the item.</param>
    /// <param name="Description">Describes the item.</param>
    /// <param name="ItemNo">A number assigned to item, which maps to the corresponding item based on ItemIndex.</param>
    /// <param name="AttributeTarget">Dictates the attribute the item targets based on AttributeType.</param>
    /// <param name="EffectPower">Dictates the potency of the skill.</param>
    public class Item
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ItemNo { get; set; }
        public int AttributeTarget { get; set; }
        public decimal EffectPower { get; set; }
    }
}
