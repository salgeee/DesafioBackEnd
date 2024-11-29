using MotoRentalApp.Models;

namespace MotoRentalApp.Controllers;
using Microsoft.AspNetCore.Mvc;
    
[ApiController]
[Route("[controller]")]

public class MotorController : ControllerBase
{
    private static List<Motorcycle> _motos = new List<Motorcycle>();
    
    [HttpPost]
    public void AddMotorcycle([FromBody] Motorcycle moto)
    {
        _motos.Add(moto);
        Console.WriteLine($"Motor added: {moto}");
        Console.WriteLine(moto.Id);
        Console.WriteLine(moto.Model);
    }
}
