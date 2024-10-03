using BaseApi.Dto.PaginationDto.Request;
using BaseApi.Dto.PaginationDto.Response;
using BaseApi.Dto.Request;
using BaseApi.Models;

namespace BaseApi.Services.GoalService
{
    public interface IGoalService
    {
        public Task<PaginatedResponseDto<Goal>> GetGoals(PaginationRequestDto paginationRequest);
        public Goal SetGoal(Goal goal);
        public Task<bool> UpdateGoal(Goal Goal);
        public bool DeleteGoal(int Id);
    }
}
