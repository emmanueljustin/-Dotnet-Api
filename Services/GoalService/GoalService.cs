using BaseApi.Dto.PaginationDto.Request;
using BaseApi.Dto.PaginationDto.Response;
using BaseApi.Models;
using BaseApi.Repository.GoalRepository;

namespace BaseApi.Services.GoalService
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;
        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task<PaginatedResponseDto<Goal>> GetGoals(PaginationRequestDto paginationRequest)
        {
            return await _goalRepository.GetGoals(paginationRequest);
        }

        public Goal SetGoal(Goal goal)
        {
            return _goalRepository.SetGoal(goal);
        }
    }
}
