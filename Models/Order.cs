namespace GoonsComicShop.Models
{
  public class Order
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string OrderNumber { get; set; }
    public double Total { get; set; }

  }
}