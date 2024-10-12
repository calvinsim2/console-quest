using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Interfaces
{
    public interface IMazeGameService
    {
        void StartGame(MazeGameDataModel mazeGameDataModel);

        MazeGameFlow MazeGameAsync(MazeGameDataModel mazeGameDataModel, MazeGameFlow startingStep);
    }
}
