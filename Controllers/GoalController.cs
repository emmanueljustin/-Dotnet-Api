using BaseApi.Dto.PaginationDto.Request;
using BaseApi.Dto.PaginationDto.Response;
using BaseApi.Dto.Request;
using BaseApi.Dto.Response;
using BaseApi.Models;
using BaseApi.Services.GoalService;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateGoal([FromBody] Goal Goal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _goalService.UpdateGoal(Goal);

            ResponseWithNoDataDto response;

            if (result)
            {
                response = new ResponseWithNoDataDto
                {
                    Status = "ok",
                    Message = "Post are succesfully updated."
                };
            }
            else
            {
                response = new ResponseWithNoDataDto
                {
                    Status = "err",
                    Message = "Oops! the data you are trying to modify does not exist."
                };
            }

            return Ok(response);
        }

        [HttpPost("delete")]
        public IActionResult DeleteGoal([FromBody] IdRequestBodyDto payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _goalService.DeleteGoal(payload.Id);

            ResponseWithNoDataDto response;

            if (result)
            {
                response = new ResponseWithNoDataDto
                {
                    Status = "ok",
                    Message = "Goal are succesfully deleted."
                };
            }
            else
            {
                response = new ResponseWithNoDataDto
                {
                    Status = "err",
                    Message = "Oops! the data you are trying to modify does not exist."
                };
            }

            return Ok(response);
        }
    }
}
