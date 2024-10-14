using MazeGameDomain.Constants;
using MazeGameDomain.Enums;

namespace MazeGameDomain.Services.DecisionTrees
{
    public class MazeGameDecisionQuery : MazeGameDecision
    {
        public MazeGameDecisionQuery() { }

        public MazeGameDecision? Positive { get; set; }
        public MazeGameDecision? Negative { get; set; }
        public Func<bool> ProcessPhase { get; set; }

        public override MazeGameFlow EvaluateAsync() 
        {
            Console.WriteLine(Title);
            Console.WriteLine(InGameMessage.BlankRow);

            bool result = ProcessPhase();

            Console.WriteLine(InGameMessage.BlankRow);
            Console.ReadKey(intercept: true);

            if (result)
            {
                return Positive!.EvaluateAsync();
            }
            else
            {
                return Negative!.EvaluateAsync();
            }
        }
    }
}
