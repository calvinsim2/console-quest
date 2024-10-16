using MazeGameDomain.Commons.Combat;
using MazeGameDomain.Commons.GenerateMonsters;
using MazeGameDomain.Constants;
using MazeGameDomain.Enums;
using MazeGameDomain.Interfaces.DecisionTrees;
using MazeGameDomain.ModelCreators;
using MazeGameDomain.Models;

namespace MazeGameDomain.Services.DecisionTrees
{
    public class FireCavern : IFireCavern
    {
        private int MapClassification { get; set; } = (int)MapType.Balanced;
        public FireCavern() { }

        public MazeGameDecisionQuery FireCaveExit { get; set; }
        public MazeGameDecisionQuery MagmaEncounter { get; set; }
        public MazeGameDecisionQuery LavaLakeTrap { get; set; }
        public MazeGameDecisionQuery LavaMorphlingEncounter { get; set; }
        public MazeGameDecisionQuery FireDragonEncounter { get; set; }
        public MazeGameDecisionQuery FireStatue { get; set; }
        public MazeGameDecisionQuery InfernalEncounter { get; set; }
        public MazeGameDecisionQuery FireBoarEncounter { get; set; }
        public MazeGameDecisionQuery FireCavernForkRoad { get; set; }
        public MazeGameDecisionQuery FireSlimeEncounter { get; set; }
        public MazeGameDecisionQuery IsAdventurerFireResistant { get; set; }

        public MazeGameDecisionQuery TransverseFireCavern(MazeGameDataModel mazeGameDataModel)
        {
            Adventurer adventurerDetail = mazeGameDataModel.Adventurer;
            FireCavernMonsterCreator fireCavernMonsterCreator = new FireCavernMonsterCreator();

            FireCaveExit = new MazeGameDecisionQuery()
            {
                Title = "You spot an exit from this hot, burning cavern! You head towards it....",

                ProcessPhase = () =>
                {
                    return true;

                },

                Positive = new MazeGameDecisionResult() { Result = MazeGameFlow.Victory }
            };

            MagmaEncounter = new MazeGameDecisionQuery()
            {
                Title = "As you near the end of the lava lake, something bigger than the morphling emerges from the lake.... a huge Magma!",

                ProcessPhase = () =>
                {
                    FireCavernMonster magma = fireCavernMonsterCreator.CreateMonster(FireCavernMonsters.GenerateMagma());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, magma, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatMagma);
                        return true;
                    }

                    return false;

                },

                Positive = FireCaveExit,
                Negative = new MazeGameDecisionResult() { Result = MazeGameFlow.Death }
            };

            LavaLakeTrap = new MazeGameDecisionQuery()
            {
                Title = "Defeating the morphling seems to have activated something... peculiar, the lava lake starts making rumbling sound! " + 
                        "You attempt to run deeper into the path to avoid the lake trap, will you successfully avoid the trap?",

                ProcessPhase = () =>
                {
                    Console.ReadKey(intercept: true);

                    Random random = new Random();
                    int randomInt = random.Next(0, 10);

                    if (randomInt < 5)
                    {
                        Console.WriteLine(InGameMessage.AvoidedTrap);
                    }
                    else
                    {
                        decimal damageTaken = 20;
                        Console.WriteLine(InGameMessage.DisplayUnableToAvoidTrapMessage(damageTaken));
                        adventurerDetail.DecreaseHealth(damageTaken);
                        Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurerDetail.Health));
                    }

                    return adventurerDetail.Health > 0;
                    
                },

                Positive = MagmaEncounter,
                Negative = new MazeGameDecisionResult() { Result = MazeGameFlow.Death }
            };

            LavaMorphlingEncounter = new MazeGameDecisionQuery()
            {
                Title = "As you trail along the path along the lava, you hear bobbling and splashing sound, a lava morphling leaps out and attacks you!",

                ProcessPhase = () =>
                {
                    FireCavernMonster lavaMorphling = fireCavernMonsterCreator.CreateMonster(FireCavernMonsters.GenerateLavaMorphling());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, lavaMorphling, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatLavaMorphling);
                        return true;
                    }

                    return false;
                },

                Positive = LavaLakeTrap,
                Negative = new MazeGameDecisionResult() { Result = MazeGameFlow.Death }
            };

            FireDragonEncounter = new MazeGameDecisionQuery()
            {
                Title = "After touching the statue, you hear a huge cry coming from behind, you quickly turned around, and you see... " + 
                "A huge Fire Dragon!",

                ProcessPhase = () =>
                {
                    FireCavernMonster fireDragon = fireCavernMonsterCreator.CreateMonster(FireCavernMonsters.GenerateFireDragon());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, fireDragon, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatFireDragon);
                        return true;
                    }

                    return false;
                },

                Positive = FireCaveExit,
                Negative = new MazeGameDecisionResult() { Result = MazeGameFlow.Death }
            };

            FireStatue = new MazeGameDecisionQuery()
            {
                Title = "As you journey on, you see an isolated statue which is not more than 6 feet tall. You placed your hand on it, " + 
                        "and you feel slightly invigorated!",

                ProcessPhase = () =>
                {
                    adventurerDetail.IncreaseHealth(50);
                    adventurerDetail.IncreaseMP(30);
                    Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurerDetail.Health));
                    Console.WriteLine(InGameMessage.AdventurerCurrentMP(adventurerDetail.MP));

                    return true;
                },

                Positive = FireDragonEncounter,
            };

            InfernalEncounter = new MazeGameDecisionQuery()
            {
                Title = "You venture further into the trail.... a huge creature that resembles a golem covered in fire makes a howling sound " +
                        "as soon as it spots you, and starts coming towards you!",

                ProcessPhase = () =>
                {
                    FireCavernMonster infernal = fireCavernMonsterCreator.CreateMonster(FireCavernMonsters.GenerateInfernal());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, infernal, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatInfernal);
                        return true;
                    }

                    return false;
                },

                Positive = FireStatue,
                Negative = new MazeGameDecisionResult() { Result = MazeGameFlow.Death }
            };

            FireBoarEncounter = new MazeGameDecisionQuery()
            {
                Title = "As soon as you step into the trail, you hear a squeak, and a charging voice coming towards you... sounds familiar, " +
                        "a BOAR! Just that it is covered with fire this time.",

                ProcessPhase = () =>
                {
                    FireCavernMonster fireBoar = fireCavernMonsterCreator.CreateMonster(FireCavernMonsters.GenerateFireBoar());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, fireBoar, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatFireBoar);
                        return true;
                    }

                    return false;
                },

                Positive = InfernalEncounter,
                Negative = new MazeGameDecisionResult() { Result = MazeGameFlow.Death }
            };

            FireCavernForkRoad = new MazeGameDecisionQuery()
            {
                Title = "You encounter a forkroad, one leads to a trail away from the lava path, another is along the lava path...",

                ProcessPhase = () =>
                {
                    bool firstPath = ForkRoad.DetermineForkRoadPath("Trail away from Lava Path", "Along Lava Path");
                    return firstPath;
                },

                Positive = FireBoarEncounter,
                Negative = LavaMorphlingEncounter
            };

            FireSlimeEncounter = new MazeGameDecisionQuery()
            {
                Title = "Fire Slime appeared, prepare for battle...",

                ProcessPhase = () =>
                {
                    FireCavernMonster fireSlime = fireCavernMonsterCreator.CreateMonster(FireCavernMonsters.GenerateFireSlime());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, fireSlime, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatFireSlime);
                        return true;
                    }

                    return false;
                },

                Positive = FireCavernForkRoad,
                Negative = new MazeGameDecisionResult() { Result = MazeGameFlow.Death }
            };

            IsAdventurerFireResistant = new MazeGameDecisionQuery()
            {
                Title = "Is Adventurer resistant to Fire?",

                ProcessPhase = () =>
                {
                    if (adventurerDetail.Class == (int)Class.Magician &&
                        adventurerDetail.Specialisation == (int)Specialisation.FireMage)
                    {
                        Console.WriteLine(InGameMessage.FireResistant);
                        return true;
                    }

                    Console.WriteLine(InGameMessage.NotFireResistant);
                    return false;
                },

                Positive = new MazeGameDecisionResult() { Result = MazeGameFlow.Victory },
                Negative = FireSlimeEncounter
            };

            return IsAdventurerFireResistant;
        }
    }
}
