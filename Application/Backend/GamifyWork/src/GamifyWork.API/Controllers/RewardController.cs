using GamifyWork.ServiceLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifyWork.API.Controllers
{
    [Route("api/reward")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly RewardService _rewardService;

        public RewardController(RewardService rewardService)
        {
            _rewardService = rewardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRewards()
        {
            var rewards = await _rewardService.GetAllRewards();
            return rewards != null ? Ok(rewards) : NotFound();
        }
    }
}
