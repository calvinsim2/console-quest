using MazeGameApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MazeGameApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MazeGameController : ControllerBase
    {
        private readonly IMazeGameApplicationService _mazeGameApplicationService;

        public MazeGameController(IMazeGameApplicationService mazeGameApplicationService)
        {
            _mazeGameApplicationService = mazeGameApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> InvokeMazeGame()
        {
            await _mazeGameApplicationService.InvokeGame();
            return Ok();
        }
    }
}
