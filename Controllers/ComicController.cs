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

    [HttpGet("{LocationsId}")]
    public List<Comic> GetAllComics(int LocationsId)
    {
      var comics = db.Comics.OrderBy(c => c.Name).Where(q => q.LocationsId == LocationsId);
      return comics.ToList();
    }

    [HttpGet("{id}/{LocationId}")]
    public Comic GetOneComic(int id, int LocationsId)
    {
      var item = db.Comics.FirstOrDefault(i => i.Id == id);//where
      return item;
    }

    [HttpPost]
    public Comic AddAComic(Comic item, int LocationsId)//async
    {
      db.Comics.Add(item);
      db.SaveChanges();//await.db.SaveChanges();
      return item;
    }

    [HttpPut("{id}/{LocationsId}")]
    public Comic UpdateAComic(int id, Comic newData, int LocationsId)
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
      return comics.ToList();
    }

    [HttpGet("numberinstock/{LocationsId}")]
    public List<Comic> LocationOutOfStock(int NumberInStock, int LocationsId)
    {
      var comics = db.Comics.Where(i => i.NumberInStock == 0).Where(q => q.LocationsId == LocationsId);
      return comics.ToList();
    }

    [HttpGet("sku/{sku}")]
    public List<Comic> GetComicBySku(string sku)
    {
      var item = db.Comics.Where(i => i.Sku == sku);
      return item.ToList();
    }

    [HttpDelete("{id}/{LocationsId}")]
    public ActionResult DeleteAComic(int id, int LocationsId)
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