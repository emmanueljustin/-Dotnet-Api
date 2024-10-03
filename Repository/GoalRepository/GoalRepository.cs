using BaseApi.Data;
using BaseApi.Dto.PaginationDto.Request;
using BaseApi.Dto.PaginationDto.Response;
using BaseApi.Dto.Request;
using BaseApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Repository.GoalRepository
{
    public class GoalRepository : IGoalRepository
    {
        private readonly DataContext _context;

        public GoalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResponseDto<Goal>> GetGoals(PaginationRequestDto paginationRequest)
        {
            var totalItems = await _context.Goals.CountAsync();
            var items = await _context.Goals
                .Skip(paginationRequest.Skip)
                .Take(paginationRequest.PageSize)
                .ToListAsync();

            var pagedResponse = new PaginatedResponseDto<Goal>(
                items,
                totalItems,
                paginationRequest.PageNumber,
                paginationRequest.PageSize
                );
            return pagedResponse;
        }

        public Goal SetGoal(Goal goal)
        {
            _context.Goals.Add(goal);
            _context.SaveChanges();

            return goal;
        }
    }
}
