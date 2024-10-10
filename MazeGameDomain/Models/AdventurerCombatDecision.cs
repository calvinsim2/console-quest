namespace MazeGameDomain.Models
{
    public class AdventurerCombatDecision
    {
        public bool PlayerDecided { get; set; }
        public AdventurerSkill? SelectedAdventurerSkill { get; set; }
    }
}
