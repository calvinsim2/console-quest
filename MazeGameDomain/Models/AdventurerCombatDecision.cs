namespace MazeGameDomain.Models
{
    /// <summary>
    /// Represents an instance that stores the skill which adventurer choses during combat. 
    /// </summary>
    /// <remarks>
    /// The AdventurerCombatDecision Class determines if Player has made a decision during combat, 
    /// and stores the skill the adventurer chose, should he/she choses combat instead of item usage.
    /// </remarks>
    public class AdventurerCombatDecision
    {
        public bool PlayerDecided { get; set; }
        public AdventurerSkill? SelectedAdventurerSkill { get; set; }
    }
}
