using System.Collections.Generic;

namespace GoonsComicShop.Models
{
  public class Locations
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string ManagerName { get; set; }
    public string PhoneNumber { get; set; }
    public List<Comic> Comics { get; set; } = new List<Comic>();
  }
}