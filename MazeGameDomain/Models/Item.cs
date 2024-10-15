namespace MazeGameDomain.Models
{
    public class Item
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ItemNo { get; set; }
        public int AttributeTarget { get; set; }
        public decimal EffectPower { get; set; }
    }
}
