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
    public class ThickForest : IThickForest
    {
        private int MapClassification { get; set; } = (int)MapType.Tight;

        public MazeGameDecisionQuery ThickForestExit { get; set; }
        public MazeGameDecisionQuery GiantEarthWolfEncounter { get; set; }
        public MazeGameDecisionQuery EarthDiety { get; set; }
        public MazeGameDecisionQuery ForestGoblinEncounter { get; set; }
        public MazeGameDecisionQuery OneEyeLizardEncounter { get; set; }
        public MazeGameDecisionQuery ForestBanditEncounter { get; set; }
        public MazeGameDecisionQuery WeirdMonkeyEncounter { get; set; }
        public MazeGameDecisionQuery ForkedRoad { get; set; }
        public MazeGameDecisionQuery MonsterReward { get; set; }
        public MazeGameDecisionQuery TreeStumpEncounter { get; set; }
        public MazeGameDecisionQuery AbandonedBackPack { get; set; }

        public ThickForest() { }

        public MazeGameDecisionQuery TransverseThickForest(MazeGameDataModel mazeGameDataModel)
        {
            Adventurer adventurerDetail = mazeGameDataModel.Adventurer;
            ThickForestMonsterCreator thickForestMonsterCreator = new ThickForestMonsterCreator();

            ThickForestExit = new MazeGameDecisionQuery()
            {
                Title = "As you bash through the last few bushes and trees, you come across a huge bridge, ahead, lies a huge castle!",

                ProcessPhase = () =>
                {
                    return true;

                },

                Positive = new MazeGameDecisionResult { Result = MazeGameFlow.Victory },
            };

            GiantEarthWolfEncounter = new MazeGameDecisionQuery
            {
                Title = "As you go forward, brace yourself.... you hear a howl... a giant wolf jumps right out and has you in its sight!",

                ProcessPhase = () =>
                {
                    ThickForestMonster giantEarthWolf = thickForestMonsterCreator.CreateMonster(ThickForestMonsters.GenerateGiantEarthWolf());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, giantEarthWolf, MapClassification);

                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatGiantEarthWolf);
                        return true;
                    }

                    return false;
                },

                Positive = ThickForestExit,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            EarthDiety = new MazeGameDecisionQuery
            {
                Title = "Continuing further... you encountered a friendly Earth Diety, he seems to have something to say....",

                ProcessPhase = () =>
                {

                    Console.WriteLine(InGameMessage.EarthDietySpeech);
                    Console.WriteLine(InGameMessage.EarthDietyRestoration);
                    Console.WriteLine(InGameMessage.BlankRow);

                    adventurerDetail.IncreaseHealth(50);
                    adventurerDetail.IncreaseMP(50);
                    Console.WriteLine(InGameMessage.AdventurerCurrentHealth(adventurerDetail.Health));
                    Console.WriteLine(InGameMessage.AdventurerCurrentMP(adventurerDetail.MP));

                    return true;
                },

                Positive = GiantEarthWolfEncounter,
            };

            ForestGoblinEncounter = new MazeGameDecisionQuery
            {
                Title = "You hear a rustling sound coming towards you, a forest goblin appears and prepares to attack!",

                ProcessPhase = () =>
                {
                    ThickForestMonster forestGoblin = thickForestMonsterCreator.CreateMonster(ThickForestMonsters.GenerateForestGoblin());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, forestGoblin, MapClassification);

                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatForestGoblin);
                        return true;
                    }

                    return false;
                },

                Positive = EarthDiety,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            OneEyeLizardEncounter = new MazeGameDecisionQuery
            {
                Title = "These thick grass ain't no laughing matter... navigating through is a pain... the next moment, a large sized green lizard " + 
                        "appeared right in front of you! Oddly, it only has a single, albeit huge eye....",

                ProcessPhase = () =>
                {
                    ThickForestMonster oneEyeLizard = thickForestMonsterCreator.CreateMonster(ThickForestMonsters.GenerateOneEyeLizard());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, oneEyeLizard, MapClassification);

                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatOneEyeLizard);
                        return true;
                    }

                    return false;
                },

                Positive = ForestGoblinEncounter,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            ForestBanditEncounter = new MazeGameDecisionQuery
            {
                Title = "As you proceed on the path, a bandit appears, he demands that you fork over all your assets!",

                ProcessPhase = () =>
                {
                    ThickForestMonster forestBandit = thickForestMonsterCreator.CreateMonster(ThickForestMonsters.GenerateForestBandit());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, forestBandit, MapClassification);

                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatForestBandit);
                        return true;
                    }

                    return false;
                },

                Positive = EarthDiety,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            WeirdMonkeyEncounter = new MazeGameDecisionQuery
            {
                Title = "An enchanted banana skin flew across you, barely missing your face by a few inch!",

                ProcessPhase = () =>
                {
                    ThickForestMonster wildMonkey = thickForestMonsterCreator.CreateMonster(ThickForestMonsters.GenerateWildMonkey());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, wildMonkey, MapClassification);

                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatWildMonkey);
                        return true;
                    }

                    return false;
                },

                Positive = ForestBanditEncounter,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            ForkedRoad = new MazeGameDecisionQuery
            {
                Title = "Yet another forkroad.... an obvious carved path that seems to been taken by many explorers earlier, and through the thick bushes...",

                ProcessPhase = () =>
                {
                    bool firstPath = ForkRoad.DetermineForkRoadPath("Carved Path", "Thick Bushes");
                    return firstPath;
                },

                Positive = WeirdMonkeyEncounter,
                Negative = OneEyeLizardEncounter,
            };

            MonsterReward = new MazeGameDecisionQuery()
            {
                Title = "Upon the death of the monster, it seems to have dropped something... it looks like a skillbook!",

                ProcessPhase = () =>
                {
                    Class adventurerClass = (Class)adventurerDetail.Class;

                    switch (adventurerClass)
                    {
                        case Class.Warrior:
                            AdventurerEnhancement.AcquireNewWarriorSkill(adventurerDetail, AdventurerSkillsCreation.PunishingSwing());
                            break;

                        case Class.Magician:
                            AdventurerEnhancement.AcquireNewMagicianSkill(adventurerDetail, adventurerDetail.Specialisation,
                                                                          AdventurerSkillsCreation.IceStrike(),
                                                                          AdventurerSkillsCreation.FlameExplosion());
                            break;

                        case Class.Archer:
                            AdventurerEnhancement.AcquireNewWarriorSkill(adventurerDetail, AdventurerSkillsCreation.ArrowRain());
                            break;
                    }

                    return true;

                },

                Positive = ForkedRoad
            };

            TreeStumpEncounter = new MazeGameDecisionQuery
            {
                Title = "The tree stump starts shuffling and comes to life! Apparently it seems attached to the backpack....",

                ProcessPhase = () =>
                {
                    ThickForestMonster treeStump = thickForestMonsterCreator.CreateMonster(ThickForestMonsters.GenerateTreeStump());
                    bool isAdventurerVictorious = Combat.CommenceCombat(adventurerDetail, treeStump, MapClassification);

                    if (isAdventurerVictorious)
                    {
                        Console.WriteLine(InGameMessage.DefeatTreeStump);
                        return true;
                    }

                    return false;
                },

                Positive = MonsterReward,
                Negative = new MazeGameDecisionResult { Result = MazeGameFlow.Death },
            };

            AbandonedBackPack = new MazeGameDecisionQuery
            {
                Title = "An abandoned backpack resting on a stump? Seems like it's left there by a previous explorer. " +
                "You got curious and opened the backback...",

                ProcessPhase = () =>
                {
                    Item hpElixir = ItemDetails.GetItemByItemNumber((int)ItemIndex.HpElixir);
                    Item mpElixir = ItemDetails.GetItemByItemNumber((int)ItemIndex.MpElixir);

                    Console.WriteLine(InGameMessage.ObtainedItemInformation(hpElixir.Name, 1));
                    Console.WriteLine(InGameMessage.ObtainedItemInformation(mpElixir.Name, 1));
                    ItemUtilisation.UpdateAdventurerInventory(hpElixir.ItemNo, adventurerDetail, true, 1);
                    ItemUtilisation.UpdateAdventurerInventory(mpElixir.ItemNo, adventurerDetail, true, 1);

                    return true;
                },

                Positive = TreeStumpEncounter,
            };

            return AbandonedBackPack;

        }
    }
}
