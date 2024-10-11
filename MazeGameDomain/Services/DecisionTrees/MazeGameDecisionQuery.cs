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
            bool result = ProcessPhase();
            Console.WriteLine(Title);
            Console.WriteLine(InGameMessage.BlankRow);

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
