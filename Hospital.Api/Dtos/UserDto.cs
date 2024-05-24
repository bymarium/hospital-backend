using Hospital.Api.Enums;

namespace Hospital.Api.Dtos
{
  public class UserDto
  {
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
  }
}
