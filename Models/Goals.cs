namespace BaseApi.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string GoalName { get; set; } = string.Empty;
        public string GoalDescription { get; set; } = string.Empty;
        public bool Achieved { get; set; } = false;
    }
}
