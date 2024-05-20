namespace Hospital.Api.Models
{
  public class Role
  {
    public int RoleId {  get; set; }
    public string Name { get; set; }
    public IEnumerable<User>? Users { get; set; }
  }
}
