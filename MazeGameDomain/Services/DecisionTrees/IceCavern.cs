using MazeGameDomain.Commons.GenerateMonsters;
using MazeGameDomain.Enums;
using MazeGameDomain.Interfaces.DecisionTrees;
using MazeGameDomain.ModelCreators;
using MazeGameDomain.Models;
using MazeGameDomain.Models.Monsters;

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
            IceCavernMonsterCreator iceCavernMonsterCreator = new IceCavernMonsterCreator();

            IceSlimeEncounter = new MazeGameDecisionQuery()
            {
                Title = "Ice Slime appeared, prepare for battle... ",

                ProcessPhase = () =>
                {
                    IceCavernMonster iceSlime = iceCavernMonsterCreator.CreateMonster(IceCavernMonsters.GenerateIceSlime());

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
