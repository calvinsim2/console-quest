using MazeGameDomain.Enums;

namespace MazeGameDomain.Services.DecisionTrees
{
    public class MazeGameDecisionQuery : MazeGameDecision
    {
        public MazeGameDecisionQuery() { }

        public MazeGameDecision? Positive { get; set; }
        public MazeGameDecision? Negative { get; set; }
        public Func<string, Task<bool>> ProcessPhase { get; set; }

        public override async Task<MazeGameFlow> EvaluateAsync(string input) 
        {
            bool result = await ProcessPhase(input);

            if (result)
            {
                return await Positive!.EvaluateAsync(input);
            }
            else
            {
                return await Negative!.EvaluateAsync(input);
            }
        }
    }
}
