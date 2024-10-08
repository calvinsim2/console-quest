using MazeGameDomain.Enums;

namespace MazeGameDomain.Services.DecisionTrees
{
    public class MazeGameDecisionResult : MazeGameDecision
    {
        public MazeGameFlow Result {  get; set; }
        public override MazeGameFlow EvaluateAsync()
        {
            return Result;
        }

    }
}
