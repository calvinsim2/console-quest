using MazeGameDomain.Models;
using MazeGameDomain.Services.DecisionTrees;

namespace MazeGameDomain.Interfaces.DecisionTrees
{
    public interface IFireCavern
    {
        MazeGameDecisionQuery TransverseFireCavern(MazeGameDataModel mazeGameDataModel);
    }
}
