using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Interfaces
{
    public interface IMazeGameService
    {
        void StartGame(MazeGameDataModel mazeGameDataModel);

        MazeGameFlow QuestGame(MazeGameDataModel mazeGameDataModel, MazeGameFlow startingStep);
    }
}
