using BaseApi.Models;

namespace BaseApi.Dto
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public UserDto User { get; set; }
    }
}
