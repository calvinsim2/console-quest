using MazeGameDomain.Enums;
using MazeGameDomain.Interfaces.DecisionTrees;
using MazeGameDomain.Models;

namespace MazeGameDomain.Services.DecisionTrees
{
    public class IceCavern : IIceCavern
    {
        public IceCavern() { }

        public MazeGameDecisionQuery IceSlimeEncounter { get; set; }
        public MazeGameDecisionQuery IsAdventurerIceResistant { get; set; }


        public async Task<MazeGameDecisionQuery> TransverseIceCavernAsync(MazeGameDataModel mazeGameDataModel)
        {
            Adventurer adventurerDetail = mazeGameDataModel.Adventurer;

            IceSlimeEncounter = new MazeGameDecisionQuery()
            {
                Title = "Ice Slime appeared, prepare for battle... ",

                ProcessPhase = () =>
                {
                    if (adventurerDetail.Class == (int)Class.Magician &&
                        adventurerDetail.Specialisation == Specialisation.IceMage)
                    {
                        return true;
                    }

                    return false;
                },

                Positive = new MazeGameDecisionResult { Result = MazeGameFlow.FireCavern },
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.FireCavern }
            };

            IsAdventurerIceResistant = new MazeGameDecisionQuery()
            {
                Title = "Is Adventurer resistant to ice? ",

                ProcessPhase = () =>
                {
                    if (adventurerDetail.Class == (int)Class.Magician &&
                        adventurerDetail.Specialisation == Specialisation.IceMage)
                    {
                        return true;
                    }

                    return false;
                },

                Positive = new MazeGameDecisionResult { Result = MazeGameFlow.FireCavern },
                Negative = IceSlimeEncounter
            };

            return IsAdventurerIceResistant;
        }
    }
}
