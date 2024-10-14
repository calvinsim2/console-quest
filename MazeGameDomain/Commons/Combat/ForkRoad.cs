using MazeGameDomain.Constants;

namespace MazeGameDomain.Commons.Combat
{
    public static class ForkRoad
    {
        public static bool DetermineForkRoadPath(string option1, string option2)
        {
            bool validuserInput = false;
            int pathChoice = 0;

            while (!validuserInput)
            {
                Console.WriteLine(InGameMessage.PromptForkRoadOptions(option1, option2));
                Console.WriteLine(InGameMessage.BlankRow);

                string userInput = Console.ReadKey(intercept: true).KeyChar.ToString();

                List<int> validPathChoice = new List<int> { 1, 2 };

                bool isValidParsing = int.TryParse(userInput, out pathChoice);

                if (isValidParsing && validPathChoice.Contains(pathChoice))
                {
                    validuserInput = true;
                }
                else
                {
                    Console.WriteLine(InGameMessage.InvalidPathSelected);
                }

            }

            bool isFirstPathChosen = pathChoice == 1;
            string chosenPathName = isFirstPathChosen ? option1 : option2;
            Console.WriteLine(InGameMessage.DisplayForkRoadDecisions(chosenPathName));

            return isFirstPathChosen;
        }
    }
}
