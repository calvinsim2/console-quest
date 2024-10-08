using MazeGameDomain.Models;
using MazeGameDomain.Services.DecisionTrees;

namespace MazeGameDomain.Interfaces.DecisionTrees
{
    public interface IIceCavern
    {
        Task<MazeGameDecisionQuery> TransverseIceCavernAsync(MazeGameDataModel mazeGameDataModel);
    }
}
