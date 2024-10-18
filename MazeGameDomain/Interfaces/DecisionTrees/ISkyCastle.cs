using MazeGameDomain.Models;
using MazeGameDomain.Services.DecisionTrees;

namespace MazeGameDomain.Interfaces.DecisionTrees
{
    public interface ISkyCastle
    {
        MazeGameDecisionQuery TransverseSkyCastle(MazeGameDataModel mazeGameDataModel);
    }
}
