using MazeGameDomain.Commons.Combat;
using MazeGameDomain.Commons.GenerateMonsters;
using MazeGameDomain.Constants;
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

        public MazeGameDecisionQuery IceCaveExit { get; set; }
        public MazeGameDecisionQuery IceYetiEncounter { get; set; }
        public MazeGameDecisionQuery BlizzardRoomTrap { get; set; }
        public MazeGameDecisionQuery ChilledWaterFountain { get; set; }
        public MazeGameDecisionQuery IceSpikeTrap { get; set; }
        public MazeGameDecisionQuery IceForkRoad { get; set; }
        public MazeGameDecisionQuery IceBoarEncounter { get; set; }
        public MazeGameDecisionQuery IceSlimeEncounter { get; set; }
        public MazeGameDecisionQuery IsAdventurerIceResistant { get; set; }


        public MazeGameDecisionQuery TransverseIceCavernAsync(MazeGameDataModel mazeGameDataModel)
        {
            Adventurer adventurerDetail = mazeGameDataModel.Adventurer;
            IceCavernMonsterCreator iceCavernMonsterCreator = new IceCavernMonsterCreator();

            IceCaveExit = new MazeGameDecisionQuery()
            {
                Title = "An exit is in sight! You make a beeline for the exit...",

                ProcessPhase = () =>
                {
                    return true;

                },

                Positive = new MazeGameDecisionResult { Result = MazeGameFlow.Victory },
            };

            IceYetiEncounter = new MazeGameDecisionQuery()
            {
                Title = "Uh oh... you hear heavy footsteps approaching and the cave starts to shake.... here comes.. a YETI!",

                ProcessPhase = () =>
                {
                    IceCavernMonster iceYeti = iceCavernMonsterCreator.CreateMonster(IceCavernMonsters.GenerateIceYeti());

                    bool isVictorious = Combat.CommenceCombat(adventurerDetail, iceYeti);

                    if (isVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatIceYeti);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                },

                Positive = IceCaveExit,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death }
            };

            BlizzardRoomTrap = new MazeGameDecisionQuery()
            {
                Title = "Seems like taking the upper path, it leads to the exit at a quicker pace, but it is full of nasty traps...." +
                "\nthere is only one path... the Blizzard Room Trap.",

                ProcessPhase = () =>
                {
                    int n = 3;

                    for (int i = 1; i <= n; i++)
                    {
                        Console.WriteLine(InGameMessage.DisplayCurrentTrapNavigation(i));
                        Console.ReadKey(intercept: true);

                        Random random = new Random();
                        int randomInt = random.Next(0, n + 1);

                        if (randomInt < i)
                        {
                            Console.WriteLine(InGameMessage.AvoidedTrap);
                            continue;
                        }

                        decimal damageTaken = i * 5;
                        Console.WriteLine(InGameMessage.DisplayUnableToAvoidTrapMessage(damageTaken));
                        adventurerDetail.DecreaseHealth(damageTaken);
                        Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurerDetail.Health));

                        if (adventurerDetail.Health <= 0)
                        {
                            return false;
                        }
                    }

                    return adventurerDetail.Health > 0;

                },

                Positive = IceCaveExit,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death }
            };

            ChilledWaterFountain = new MazeGameDecisionQuery()
            {
                Title = "You come across a small room, inside, there is a small water fountain, you drink the water from it" +
                        "\n it tastes great! Your hp is recovered slightly!",

                ProcessPhase = () =>
                {
                    adventurerDetail.IncreaseHealth(10);
                    Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurerDetail.Health));
                    return true;

                },

                Positive = IceYetiEncounter,
            };

            IceSpikeTrap = new MazeGameDecisionQuery()
            {
                Title = "OH NO! You stumbled onto an ice spike trap!",

                ProcessPhase = () =>
                {
                    adventurerDetail.DecreaseHealth(10);
                    Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurerDetail.Health));

                    return adventurerDetail.Health > 0;
                },

                Positive = BlizzardRoomTrap,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death }
            };

            IceForkRoad = new MazeGameDecisionQuery()
            {
                Title = "You come across a forkroad, one seemingly leads to a higher level, another one deeper into the cavern...",

                ProcessPhase = () =>
                {
                    bool firstPath = ForkRoad.DetermineForkRoadPath("Higher Level", "Deeper into Cavern");
                    return firstPath;
                },

                Positive = IceSpikeTrap,
                Negative = ChilledWaterFountain
            };

            IceBoarEncounter = new MazeGameDecisionQuery()
            {
                Title = "You hear a squeak, and a charging voice coming towards you... before you knew it, an Ice Boar knocks you over!",

                ProcessPhase = () =>
                {
                    IceCavernMonster iceBoar = iceCavernMonsterCreator.CreateMonster(IceCavernMonsters.GenerateIceBoar());

                    bool isVictorious = Combat.CommenceCombat(adventurerDetail, iceBoar);

                    if (isVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatIceBoar);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                },

                Positive = IceForkRoad,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death }
            };

            IceSlimeEncounter = new MazeGameDecisionQuery()
            {
                Title = "Ice Slime appeared, prepare for battle... ",

                ProcessPhase = () =>
                {
                    IceCavernMonster iceSlime = iceCavernMonsterCreator.CreateMonster(IceCavernMonsters.GenerateIceSlime());

                    bool isVictorious = Combat.CommenceCombat(adventurerDetail, iceSlime);

                    if (isVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatIceSlime);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                },

                Positive = IceBoarEncounter,
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
                        Console.WriteLine(InGameMessage.IceResistant);
                        return true;
                    }

                    Console.WriteLine(InGameMessage.NotIceResistant);

                    return false;
                },

                Positive = new MazeGameDecisionResult { Result = MazeGameFlow.Victory },
                Negative = IceSlimeEncounter
            };

            return IsAdventurerIceResistant;
        }
    }
}
