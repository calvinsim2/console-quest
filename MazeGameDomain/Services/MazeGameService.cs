using MazeGameDomain.Commons;
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
        private readonly IFireCavern _fireCavern;
        public MazeGameService(IIceCavern iceCavern, IFireCavern fireCavern) 
        {
            _iceCavern = iceCavern;
            _fireCavern = fireCavern; 
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
                        currentStep = ExecuteTownFlow(mazeGameDataModel);
                        break;

                    case MazeGameFlow.IceCavern:
                        currentStep = ExecuteIceCavernFlow(mazeGameDataModel);
                        break;

                    case MazeGameFlow.FireCavern:
                        currentStep = ExecuteFireCavernFlow(mazeGameDataModel);
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

        private MazeGameFlow ExecuteTownFlow(MazeGameDataModel mazeGameDataModel)
        {
            Console.WriteLine(InGameMessage.BlankRow);
            Console.WriteLine(InGameMessage.Town);
            Console.WriteLine(InGameMessage.BlankRow);
            AdventurerEnhancement.AssignSpecialisation(mazeGameDataModel);
            Console.WriteLine(InGameMessage.BlankRow);
            Console.ReadKey(intercept: true);
            return MazeGameFlow.IceCavern;
        }

        private MazeGameFlow ExecuteIceCavernFlow(MazeGameDataModel mazeGameDataModel)
        {
            Console.WriteLine(InGameMessage.BlankRow);
            Console.WriteLine(InGameMessage.IceCavern);
            Console.WriteLine(InGameMessage.BlankRow);
            MazeGameDecisionQuery iceCavernCreate = _iceCavern.TransverseIceCavern(mazeGameDataModel);
            MazeGameFlow currentStep = iceCavernCreate.EvaluateAsync();

            return currentStep;
        }

        private MazeGameFlow ExecuteFireCavernFlow(MazeGameDataModel mazeGameDataModel)
        {
            Console.WriteLine(InGameMessage.BlankRow);
            Console.WriteLine(InGameMessage.FireCavern);
            Console.WriteLine(InGameMessage.BlankRow);
            MazeGameDecisionQuery fireCavernCreate = _fireCavern.TransverseFireCavern(mazeGameDataModel);
            MazeGameFlow currentStep = fireCavernCreate.EvaluateAsync();

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
