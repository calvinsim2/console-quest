using MazeGameDomain.Commons.Combat;
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


        public MazeGameDecisionQuery TransverseIceCavernAsync(MazeGameDataModel mazeGameDataModel)
        {
            Adventurer adventurerDetail = mazeGameDataModel.Adventurer;
            IceCavernMonsterCreator iceCavernMonsterCreator = new IceCavernMonsterCreator();

            IceSlimeEncounter = new MazeGameDecisionQuery()
            {
                Title = "Ice Slime appeared, prepare for battle... ",

                ProcessPhase = () =>
                {
                    IceCavernMonster iceSlime = iceCavernMonsterCreator.CreateMonster(IceCavernMonsters.GenerateIceSlime());

                    return Combat.CommenceCombat(adventurerDetail, iceSlime);
                    
                },

                Positive = new MazeGameDecisionResult { Result = MazeGameFlow.Victory },
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death }
            };

            IsAdventurerIceResistant = new MazeGameDecisionQuery()
            {
                Title = "Is Adventurer resistant to ice? ",

                ProcessPhase = () =>
                {
                    if (adventurerDetail.Class == (int)Class.Magician &&
                        adventurerDetail.Specialisation == (int)Specialisation.IceMage)
                    {
                        return true;
                    }

                    return false;
                },

                Positive = new MazeGameDecisionResult { Result = MazeGameFlow.Victory },
                Negative = IceSlimeEncounter
            };

            return IsAdventurerIceResistant;
        }
    }
}
