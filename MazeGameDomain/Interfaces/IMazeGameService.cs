using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Interfaces
{
    public interface IMazeGameService
    {
        Task StartGame(MazeGameDataModel mazeGameDataModel);

        Task<MazeGameFlow> MazeGameAsync(MazeGameDataModel mazeGameDataModel, MazeGameFlow startingStep);
    }
}
