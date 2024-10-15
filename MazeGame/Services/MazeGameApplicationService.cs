using Figgle;
using MazeGameApplication.Interfaces;
using MazeGameDomain.Commons.Skills;
using MazeGameDomain.Constants;
using MazeGameDomain.Enums;
using MazeGameDomain.Interfaces;
using MazeGameDomain.Models;

namespace MazeGameApplication.Services
{
    public class MazeGameApplicationService : IMazeGameApplicationService
    {
        private readonly IMazeGameService _mazeGameService;

        public MazeGameApplicationService(IMazeGameService mazeGameService)
        {
            _mazeGameService = mazeGameService;
        }

        public void InvokeGame()
        {
            Console.WriteLine(FiggleFonts.Standard.Render("ConsoleQuest"));
            InGameMessage.Introduction();
            MazeGameDataModel mazeGameDataModel = GetGameRequiredDetails();
            _mazeGameService.StartGame(mazeGameDataModel);
        } 

        private MazeGameDataModel GetGameRequiredDetails()
        {
            MazeGameDataModel mazeGameDataModel = new MazeGameDataModel();
            mazeGameDataModel.Adventurer = GetAdventurerDetails();

            return mazeGameDataModel;
        }

        private Adventurer GetAdventurerDetails()
        {
            Adventurer adventurer = new Adventurer();

            adventurer.Name = GetName();
            adventurer.Class = GetClass();
            adventurer.Skills = AssignClassSkills(adventurer.Class);
            adventurer.Health = DetermineHealth(adventurer.Class);
            adventurer.MP = DetermineMP(adventurer.Class);
            adventurer.Inventory = AssignStartingInventories();

            return adventurer;

        }

        private string GetName()
        {
            Console.WriteLine(InGameMessage.PromptName);

            string inputName = Console.ReadLine();

            return inputName;
        }

        private int GetClass()
        {
            Console.WriteLine(InGameMessage.ChooseClass);
            Console.WriteLine(InGameMessage.BlankRow);

            Console.WriteLine(InGameMessage.Warrior);
            Console.WriteLine(InGameMessage.BlankRow);

            Console.WriteLine(InGameMessage.Magician);
            Console.WriteLine(InGameMessage.BlankRow);

            Console.WriteLine(InGameMessage.Archer);
            Console.WriteLine(InGameMessage.BlankRow);

            Console.WriteLine(InGameMessage.PromptClassSelection);

            bool validClassSelection = false;
            List<string> validClasses = new List<string> { "1", "2", "3" };
            int classSelection = 0;

            while (!validClassSelection)
            {
                string userInput = Console.ReadKey(intercept: true).KeyChar.ToString();

                if (!validClasses.Contains(userInput))
                {
                    Console.WriteLine(InGameMessage.InvalidClassSelection);
                    Console.WriteLine(InGameMessage.BlankRow);
                    continue;
                }

                classSelection = Convert.ToInt32(userInput);

                // Cast the integer value to the enum type
                Class selectedClass = (Class)classSelection;

                Console.WriteLine($"You selected: {selectedClass}");
                validClassSelection = true;
            }

            return classSelection;

        }

        private ICollection<AdventurerSkill> AssignClassSkills(int adventurerClass)
        {
            List<AdventurerSkill> defaultSkills = new List<AdventurerSkill>();
            Class adventurerClassEnum = (Class)adventurerClass;

            switch (adventurerClassEnum)
            {
                case Class.Warrior:
                    defaultSkills = AdventurerSkillsCreation.WarriorDefaultSkills().ToList();
                    break;

                case Class.Magician:
                    defaultSkills = AdventurerSkillsCreation.MagicianDefaultSkills().ToList();
                    break;

                case Class.Archer:
                    defaultSkills = AdventurerSkillsCreation.BowmanDefaultSkills().ToList();
                    break;

                default: break;
            }

            return defaultSkills;
        }

        public Dictionary<int, int> AssignStartingInventories()
        {
            return new Dictionary<int, int> { { (int)ItemIndex.HpPotion, 3 }, { (int)ItemIndex.MpPotion, 1 } };
        }

        private decimal DetermineHealth(int adventurerClass)
        {
            decimal baseHealth = 100m;
            Class adventurerClassEnum = (Class)adventurerClass;

            switch (adventurerClassEnum)
            {
                case Class.Warrior:
                    baseHealth *= 1.5m;
                    break;

                case Class.Magician:
                    baseHealth *= 0.75m;
                    break;

                default: break;
            }

            return baseHealth;
        }

        private decimal DetermineMP(int adventurerClass)
        {
            decimal baseMp = 100m;
            Class adventurerClassEnum = (Class)adventurerClass;

            switch (adventurerClassEnum)
            {

                case Class.Magician:
                    baseMp *= 2m;
                    break;

                default: break;
            }

            return baseMp;
        }
    }
}
