using BaseApi.Dto.PaginationDto.Request;
using BaseApi.Dto.PaginationDto.Response;
using BaseApi.Dto.Request;
using BaseApi.Dto.Response;
using BaseApi.Models;
using BaseApi.Services.GoalService;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : Controller
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpPost("get")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<GetGoalResponseDto<PaginatedResponseDto<Goal>>>))]
        public async Task<IActionResult> GetGoals([FromBody] PaginationRequestDto paginationRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _goalService.GetGoals(paginationRequest);

            var response = new GetGoalResponseDto<PaginatedResponseDto<Goal>>
            {
                Status = "ok",
                Message = "Here is your list of goals.",
                Data = data,
            };

            return Ok(response);
        }

        [HttpPost("set")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Goal>))]
        public IActionResult SetGoal([FromBody] SetGoalRequestDto payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var goal = new Goal
            {
                GoalName = payload.GoalName,
                GoalDescription = payload.GoalDescription,
                Achieved = payload.IsAchieved,
            };

            var response = _goalService.SetGoal(goal);

            return Ok(response);
        }
    }
}
