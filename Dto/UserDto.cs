using BaseApi.Models;

namespace BaseApi.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public ICollection<Post> Posts { get; set; }
    }
}
