using MazeGameDomain.Commons.Skills;
using MazeGameDomain.Constants;
using MazeGameDomain.Enums;
using MazeGameDomain.Models;

namespace MazeGameDomain.Commons
{
    public static class AdventurerEnhancement
    {
        public static void AssignSpecialisation(MazeGameDataModel mazeGameDataModel)
        {
            Adventurer adventurer = mazeGameDataModel.Adventurer;
            if (adventurer.Class == (int)Class.Magician)
            {
                MagicianSpecialisation(adventurer);
            }
        }

        public static void MagicianSpecialisation(Adventurer adventurer)
        {
            Console.WriteLine(InGameMessage.MagicianSpecialisationDescription);
            bool specialisationChosen = false;

            while (!specialisationChosen) 
            {
                Console.WriteLine(InGameMessage.PromptMagicianSpecialisation);
                string userInput = Console.ReadKey(intercept: true).KeyChar.ToString();

                List<int> validSpecialisationChoice = new List<int> { (int)Specialisation.IceMage, (int)Specialisation.FireMage };

                bool isValidParsing = int.TryParse(userInput, out int specialisationChoice);

                if (isValidParsing && validSpecialisationChoice.Contains(specialisationChoice))
                {
                    Console.WriteLine(InGameMessage.DisplayAdventurerSelectedSpecialisation(specialisationChoice));
                    adventurer.Specialisation = specialisationChoice;
                    AcquireNewMagicianSkill(adventurer, specialisationChoice, AdventurerSkillsCreation.ColdBeam(), AdventurerSkillsCreation.FireArrow());
                    specialisationChosen = true;
                }
                else
                {
                    Console.WriteLine(InGameMessage.InvalidSpecialisationSelected);
                }
            }
            
        }

        public static void AcquireNewWarriorSkill(Adventurer adventurer, AdventurerSkill warriorSkill)
        {
            adventurer.Skills.Add(warriorSkill);
            Console.WriteLine(InGameMessage.DisplayLearntNewSkillMessage(warriorSkill));
        }

        public static void AcquireNewMagicianSkill(Adventurer adventurer, int specialisationChoice, 
                                                   AdventurerSkill iceMageSkill, AdventurerSkill fireMageSkill)
        {
            AdventurerSkill learntAdventurerSkill = specialisationChoice == (int)Specialisation.IceMage ? iceMageSkill : fireMageSkill;
            adventurer.Skills.Add(learntAdventurerSkill);

            Console.WriteLine(InGameMessage.DisplayLearntNewSkillMessage(learntAdventurerSkill));
        }

        public static void AcquireNewArcherSkill(Adventurer adventurer, AdventurerSkill archerSkill)
        {
            adventurer.Skills.Add(archerSkill);
            Console.WriteLine(InGameMessage.DisplayLearntNewSkillMessage(archerSkill));
        }
    }
}
