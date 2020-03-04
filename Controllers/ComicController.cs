using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GoonsComicShop.Models;
using Microsoft.EntityFrameworkCore;

namespace GoonsComicShop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ComicController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet]
    public List<Comic> GetAllComics()
    {
      var comics = db.Comics.OrderBy(c => c.Name);
      return comics.ToList();
    }

    [HttpGet("{id}")]
    public Comic GetOneComic(int id)
    {
      var item = db.Comics.FirstOrDefault(i => i.Id == id);
      return item;
    }
    [HttpPost]
    public Comic AddAComic(Comic item)//async
    {
      db.Comics.Add(item);
      db.SaveChanges();//await.db.SaveChanges();
      return item;
    }
    [HttpPut("{id}")]
    public Comic UpdateAComic(int id, Comic newData)
    {
      newData.Id = id;
      db.Entry(newData).State = EntityState.Modified;
      db.SaveChanges();
      return newData;
    }

    [HttpGet("noinv")]
    public List<Comic> OutOfStock(int NumberInStock)
    {
      var comics = db.Comics.Where(i => i.NumberInStock == 0);
      foreach (var comic in comics)
      {
        Console.WriteLine($"{comic.Name}");
      }
      return comics.ToList();
    }
    [HttpGet("sku/{sku}")]
    public Comic GetComicBySku(string sku)
    {
      var item = db.Comics.FirstOrDefault(i => i.Sku == sku);
      return item;
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteAComic(int id)
    {
      var item = db.Comics.FirstOrDefault(d => d.Id == id);
      if (item == null)
      {
        return NotFound();
      }
      db.Comics.Remove(item);
      db.SaveChanges();
      return Ok();
    }
  }
}