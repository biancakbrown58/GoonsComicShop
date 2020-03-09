using System;
using System.Collections.Generic;

namespace GoonsComicShop.Models
{
  public class Comic
  {
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int NumberInStock { get; set; }
    public double Price { get; set; }
    public DateTime DateOrdered { get; set; } = DateTime.Now;
    public int? LocationsId { get; set; }
    public Locations Locations { get; set; }

    public List<ComicOrders> ComicOrders { get; set; } = new List<ComicOrders>();
  }
}