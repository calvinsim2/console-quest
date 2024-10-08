using MazeGameDomain.Enums;
using MazeGameDomain.Interfaces;
using MazeGameDomain.Interfaces.DecisionTrees;
using MazeGameDomain.Models;
using MazeGameDomain.Services.DecisionTrees;

namespace MazeGameDomain.Services
{
    public class MazeGameService : IMazeGameService
    {
        private readonly IIceCavern _iceCavern;
        public MazeGameService(IIceCavern iceCavern) 
        {
            _iceCavern = iceCavern;
        }

        public async Task StartGame(MazeGameDataModel mazeGameDataModel)
        {

        }
        public async Task<MazeGameFlow> MazeGameAsync(MazeGameDataModel mazeGameDataModel, 
                                                      MazeGameFlow startingStep = MazeGameFlow.Town)
        {
            MazeGameFlow currentStep = startingStep;
            MazeGameFlow breaktree = startingStep;

            while (breaktree == startingStep)
            {
                switch (currentStep)
                {
                    case MazeGameFlow.Town:
                        currentStep = MazeGameFlow.IceCavern;
                        break;

                    case MazeGameFlow.IceCavern:
                        MazeGameDecisionQuery iceCavernCreate = await _iceCavern.TransverseIceCavernAsync(mazeGameDataModel);
                        currentStep = await iceCavernCreate.EvaluateAsync(string.Empty);
                        break;

                    case MazeGameFlow.FireCavern:
                        break;

                    default: break;
                }
            }

            return currentStep;
        }
    }
}
