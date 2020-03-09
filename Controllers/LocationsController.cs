using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoonsComicShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoonsComicShop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LocationsController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();

    [HttpGet]
    public async Task<ActionResult<List<Locations>>> GetAllLocations()
    {
      return await db.Locations.OrderBy(l => l.Address).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Locations>> AddLocation(Locations locations)
    {
      await db.Locations.AddAsync(locations);
      await db.SaveChangesAsync();
      return locations;
    }

  }
}