using MazeGameDomain.Models;
using MazeGameDomain.Services.DecisionTrees;

namespace MazeGameDomain.Interfaces.DecisionTrees
{
    public interface IIceCavern
    {
        MazeGameDecisionQuery TransverseIceCavernAsync(MazeGameDataModel mazeGameDataModel);
    }
}
