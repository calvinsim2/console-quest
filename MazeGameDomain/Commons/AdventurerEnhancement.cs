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

                List<int> validSpecialisationChoice = new List<int> { 1, 2 };

                bool isValidParsing = int.TryParse(userInput, out int specialisationChoice);

                if (isValidParsing && validSpecialisationChoice.Contains(specialisationChoice))
                {
                    Console.WriteLine(InGameMessage.DisplayAdventurerSelectedSpecialisation(specialisationChoice));
                    adventurer.Specialisation = specialisationChoice;
                    specialisationChosen = true;
                }
                else
                {
                    Console.WriteLine(InGameMessage.InvalidSpecialisationSelected);
                }
            }
            
        }
    }
}
