using MazeGameDomain.Models;
using MazeGameDomain.Services.DecisionTrees;

namespace MazeGameDomain.Interfaces.DecisionTrees
{
    public interface IThickForest
    {
        MazeGameDecisionQuery TransverseThickForest(MazeGameDataModel mazeGameDataModel);
    }
}
