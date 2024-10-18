using MazeGameDomain.Commons;
using MazeGameDomain.Commons.Combat;
using MazeGameDomain.Commons.GenerateMonsters;
using MazeGameDomain.Commons.Items;
using MazeGameDomain.Commons.Skills;
using MazeGameDomain.Constants;
using MazeGameDomain.Enums;
using MazeGameDomain.Interfaces.DecisionTrees;
using MazeGameDomain.ModelCreators;
using MazeGameDomain.Models;

namespace MazeGameDomain.Services.DecisionTrees
{
    public class SkyCastle : ISkyCastle
    {
        private int MapClassification { get; set; } = (int)MapType.Wide;
        public SkyCastle() { }

        public MazeGameDecisionQuery SkyCastleExit { get; set; }
        public MazeGameDecisionQuery WindDragonEncounter { get; set; }
        public MazeGameDecisionQuery EnchantedWindShrine { get; set; }
        public MazeGameDecisionQuery CrazedWindWizardEncounter { get; set; }
        public MazeGameDecisionQuery AbandonedAdventurerStash { get; set; }
        public MazeGameDecisionQuery CockatriceEncounter { get; set; }
        public MazeGameDecisionQuery GryphonEncounter { get; set; }
        public MazeGameDecisionQuery IsolatedWindChest { get; set; }
        public MazeGameDecisionQuery WindVultureEncounter { get; set; }
        public MazeGameDecisionQuery CastleWallAndGroundForkRoad { get; set; }
        public MazeGameDecisionQuery SkeletonArcherEncounter { get; set; }

        public MazeGameDecisionQuery TransverseSkyCastle(MazeGameDataModel mazeGameDataModel)
        {
            Adventurer adventurerDetail = mazeGameDataModel.Adventurer;
            SkyCastleMonsterCreator skyCastleMonsterCreator = new SkyCastleMonsterCreator();

            SkyCastleExit = new MazeGameDecisionQuery()
            {
                Title = "Beyond the shrine, it's a backdoor exit from the castle, with the castle now cleared of monsters, you proceed towards the back exit...",

                ProcessPhase = () =>
                {
                    return true;
                },

                Positive = new MazeGameDecisionResult() { Result = MazeGameFlow.Victory }
            };

            WindDragonEncounter = new MazeGameDecisionQuery
            {
                Title = "Extreme winds are picking up, you almost got blown away, you quickly held on onto the shrine, which prevents you from being brought " + 
                        "awaay like the wind, the next moment, a HUGE wind dragon, with white and silver scales, appeared and commence its attack!",

                ProcessPhase = () =>
                {
                    SkyCastleMonster windDragon = skyCastleMonsterCreator.CreateMonster(SkyCastleMonsters.GenerateCrazedWindDragon());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, windDragon, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatWindDragon);
                        return true;
                    }

                    return false;
                },

                Positive = SkyCastleExit,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            EnchantedWindShrine = new MazeGameDecisionQuery
            {
                Title = "As you progress.... you eventually reach the Wind Shrine, although abandoned, its powers still remain. Approaching this " +
                        "shrine slightly recovers your lost vitality, and there are some items lying around, perhaps by some previous explorer?",

                ProcessPhase = () =>
                {
                    adventurerDetail.IncreaseHealth(60);
                    adventurerDetail.IncreaseMP(40);
                    Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurerDetail.Health));
                    Console.WriteLine(InGameMessage.AdventurerCurrentMP(adventurerDetail.MP));

                    ItemDetails.ObtainNewItems((int)ItemIndex.HpElixir, 3, adventurerDetail);
                    ItemDetails.ObtainNewItems((int)ItemIndex.MpElixir, 3, adventurerDetail);

                    return true;
                },

                Positive = WindDragonEncounter,
            };

            CrazedWindWizardEncounter = new MazeGameDecisionQuery
            {
                Title = "You heard someone mumbling to himself right across the other room... you went over to check it out, you see an old man, " + 
                        "seems like he's a fallen wizard... when he sees you, he immediately went BERSERK and starts attacking you!",

                ProcessPhase = () =>
                {
                    SkyCastleMonster crazedWindWizard = skyCastleMonsterCreator.CreateMonster(SkyCastleMonsters.GenerateCrazedWindWizard());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, crazedWindWizard, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatCrazedOldWizard);
                        return true;
                    }

                    return false;
                },

                Positive = EnchantedWindShrine,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            AbandonedAdventurerStash = new MazeGameDecisionQuery
            {
                Title = "You come across an abandoned small room, you see some destroyed weapons and items lying around, you scavange to see " + 
                        "if there are anything usable....",

                ProcessPhase = () =>
                {

                    ItemDetails.ObtainNewItems((int)ItemIndex.HpElixir, 1, adventurerDetail);
                    ItemDetails.ObtainNewItems((int)ItemIndex.MpElixir, 1, adventurerDetail);

                    return true;
                },

                Positive = CrazedWindWizardEncounter,
            };


            CockatriceEncounter = new MazeGameDecisionQuery
            {
                Title = "As you walk through the abandoned castle, you heard some clucking sound... when the creature emerges, you see for " +
                        "yourself, a creature that has a chicken body, and a SNAKE TAIL?!",

                ProcessPhase = () =>
                {
                    SkyCastleMonster cockatrice = skyCastleMonsterCreator.CreateMonster(SkyCastleMonsters.GenerateCockatrice());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, cockatrice, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatCockatrice);
                        return true;
                    }

                    return false;
                },

                Positive = AbandonedAdventurerStash,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            GryphonEncounter = new MazeGameDecisionQuery
            {
                Title = "Look out! A huge avian creature appeared beneath the castle walls and comes towards you with its HUGE claws!",

                ProcessPhase = () =>
                {
                    SkyCastleMonster gryphon = skyCastleMonsterCreator.CreateMonster(SkyCastleMonsters.GenerateGryphon());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, gryphon, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatGryphon);
                        return true;
                    }

                    return false;
                },

                Positive = EnchantedWindShrine,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            IsolatedWindChest = new MazeGameDecisionQuery
            {
                Title = "Lying along the pavement on the castle wall, you see a silver chest laying on the ground. You can see some magical wind " +
                        "swirling around the chest, fascinatedly, you opened the chest... " +
                        "You found an old rusty skillbook along some goodies!",

                ProcessPhase = () =>
                {
                    AdventurerEnhancement.AcquireNewCommonSkill(adventurerDetail, AdventurerSkillsCreation.WindRestoration());
                    Console.WriteLine(InGameMessage.BlankRow);

                    ItemDetails.ObtainNewItems((int)ItemIndex.HpElixir, 2, adventurerDetail);
                    ItemDetails.ObtainNewItems((int)ItemIndex.MpElixir, 2, adventurerDetail);

                    return true;
                },

                Positive = GryphonEncounter,
            };

            WindVultureEncounter = new MazeGameDecisionQuery
            {
                Title = "Upon reaching the top of the castle wall, wind starts to pick up... not long after, a squawk sound can be heard. " +
                        "You immediately see a vulture diving towards you!",

                ProcessPhase = () =>
                {
                    SkyCastleMonster windVulture = skyCastleMonsterCreator.CreateMonster(SkyCastleMonsters.GenerateWindVulture());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, windVulture, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatWindVulture);
                        return true;
                    }

                    return false;
                },

                Positive = IsolatedWindChest,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            CastleWallAndGroundForkRoad = new MazeGameDecisionQuery()
            {
                Title = "As you pass through the gates, you have a choice to make, take the stairs to the castle walls and enjoy the sceneic route, " +
                        "or stick to the ground floor...",

                ProcessPhase = () =>
                {
                    bool firstPath = ForkRoad.DetermineForkRoadPath("Castle Walls", "Ground Floor");
                    return firstPath;
                },

                Positive = WindVultureEncounter,
                Negative = CockatriceEncounter
            };

            SkeletonArcherEncounter = new MazeGameDecisionQuery
            {
                Title = "You see a skeleton roaming around back and forth at the entrance, it is holding... a bow? Suddenly, it detects your presence, " +
                "turn its head (or skull) towards you, and starting taking aim at you!",

                ProcessPhase = () =>
                {
                    SkyCastleMonster skeletonArcher = skyCastleMonsterCreator.CreateMonster(SkyCastleMonsters.GenerateSkeletonArcher());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, skeletonArcher, MapClassification);
                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatSkeletonArcher);
                        return true;
                    }

                    return false;
                },

                Positive = CastleWallAndGroundForkRoad,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            return SkeletonArcherEncounter;

        }
    }
}
