namespace BaseApi.Dto.Request
{
    public class SetGoalRequestDto
    {
        public string GoalName { get; set; }
        public string GoalDescription { get; set; }
        public bool IsAchieved { get; set; }
    }
}
