using MazeGameDomain.Enums;

namespace MazeGameDomain.Services.DecisionTrees
{
    public class MazeGameDecisionResult : MazeGameDecision
    {
        public MazeGameFlow Result {  get; set; }
        public override async Task<MazeGameFlow> EvaluateAsync(string input)
        {
            return await Task.FromResult(Result);
        }

    }
}
