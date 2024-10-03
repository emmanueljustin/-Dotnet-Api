using BaseApi.Dto.PaginationDto.Request;
using BaseApi.Dto.PaginationDto.Response;
using BaseApi.Dto.Request;
using BaseApi.Models;

namespace BaseApi.Repository.GoalRepository
{
    public interface IGoalRepository
    {
        public Task<PaginatedResponseDto<Goal>> GetGoals(PaginationRequestDto paginationRequest);
        public Goal SetGoal(Goal goal);
        public Task<bool> UpdateGoal(Goal Goal);
        public bool DeleteGoal(int Id);
    }
}
