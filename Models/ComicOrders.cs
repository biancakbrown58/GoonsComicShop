namespace GoonsComicShop.Models
{
  public class ComicOrders
  {
    public int Id { get; set; }

    public int ComicId { get; set; }
    public Comic Comic { get; set; }

    public int OrderId { get; set; }
    public Order Orders { get; set; }
  }
}