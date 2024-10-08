using MazeGameDomain.Enums;

namespace MazeGameDomain.Services.DecisionTrees
{
    public abstract class MazeGameDecision
    {
        public string? Title { get; set; }

        public abstract Task<MazeGameFlow> EvaluateAsync(string input);
    }
}
