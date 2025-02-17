namespace BaseApi.Models
{
  public class User
  {
    public int Id { get; set;}
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set;}
    public string LastName { get; set;}
    public string Gender { get; set;}
    public int Age { get; set;}
    public ICollection<Post> Posts { get; set;}
  }
}
