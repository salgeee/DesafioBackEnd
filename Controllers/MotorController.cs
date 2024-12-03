using MongoDB.Driver;
using MotoRentalApp.Data;
using MotoRentalApp.Models;

namespace MotoRentalApp.Controllers;
using Microsoft.AspNetCore.Mvc;
    
[ApiController]
[Route("motos")]

public class MotorController : ControllerBase
{
    private readonly MotorcycleContext _context;

    public MotorController(MotorcycleContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public IActionResult AddMotorcycle([FromBody] Motorcycle moto)
    {
        _context.Motorcycles.InsertOne(moto);
        return CreatedAtAction(nameof(GetForIdentifier), 
            new { id = moto.Identifier },
            moto);
    }
    
    [HttpGet]
    public IEnumerable<Motorcycle> GetMotors([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
    {
        return _context.Motorcycles.Find(_ => true)
            .Skip(skip)
            .Limit(take)
            .ToList();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetForIdentifier(string id)
    {
       var moto =  _context.Motorcycles.Find(m => m.Identifier == id).FirstOrDefault();
       if (moto == null) return NotFound();
       return Ok(moto);
    }


    
}
