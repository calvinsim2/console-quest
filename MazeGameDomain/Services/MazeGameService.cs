using MazeGameDomain.Constants;
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

        public void StartGame(MazeGameDataModel mazeGameDataModel)
        {
            MazeGameAsync(mazeGameDataModel);
        }
        public MazeGameFlow MazeGameAsync(MazeGameDataModel mazeGameDataModel, 
                                                      MazeGameFlow startingStep = MazeGameFlow.Town)
        {
            MazeGameFlow currentStep = startingStep;

            while (currentStep != MazeGameFlow.EndGame)
            {
                switch (currentStep)
                {
                    case MazeGameFlow.Town:
                        currentStep = MazeGameFlow.IceCavern;
                        break;

                    case MazeGameFlow.IceCavern:
                        MazeGameDecisionQuery iceCavernCreate = _iceCavern.TransverseIceCavernAsync(mazeGameDataModel);
                        currentStep = iceCavernCreate.EvaluateAsync();
                        break;

                    case MazeGameFlow.FireCavern:
                        break;

                    case MazeGameFlow.Death:
                        currentStep = ExecuteDeathFlow();
                        break;

                    case MazeGameFlow.Victory:
                        currentStep = ExecuteCompleteFlow();
                        break;

                    case MazeGameFlow.EndGame:
                        break;

                    default: break;
                }
            }

            return currentStep;
        }

        private MazeGameFlow ExecuteDeathFlow()
        {
            Console.WriteLine(InGameMessage.BlankRow);
            Console.WriteLine(InGameMessage.Death);
            Console.WriteLine(InGameMessage.BlankRow);

            return MazeGameFlow.EndGame;
        }

        private MazeGameFlow ExecuteCompleteFlow()
        {
            Console.WriteLine(InGameMessage.BlankRow);
            Console.WriteLine(InGameMessage.Complete);
            Console.WriteLine(InGameMessage.BlankRow);

            return MazeGameFlow.EndGame;
        }
    }
}
