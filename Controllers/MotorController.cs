using MongoDB.Driver;
using MotoRentalApp.Data;
using MotoRentalApp.Data.DTOs;
using MotoRentalApp.Models;

namespace MotoRentalApp.Controllers;
using Microsoft.AspNetCore.Mvc;
    
[ApiController]
[Route("motos")]
[Tags("Motos")]
public class MotorController : ControllerBase
{
    private readonly MotorcycleContext _context;

    public MotorController(MotorcycleContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Cadastrar uma nova moto
    /// </summary>
    /// <param name="motoDto">Objeto com os campos necessários para cadastrar uma nova moto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201"> Caso a moto seja cadastrada com sucesso</response>
    /// <response code="400"> Dados inválidos</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)] 
    public IActionResult AddMotorcycle([FromBody] CreateMotoDto motoDto)
    {
        
        var existingMoto = _context.Motorcycles.Find(m => m.Identifier == motoDto.Identifier).FirstOrDefault();
        if (existingMoto != null)
        {
            return BadRequest(new { mensagem = "Já existe uma moto cadastrada com este Id." });
        }
        
        if (!ModelState.IsValid)
        {
            return BadRequest(new { mensagem = "Dados inválidos" });
        }
        
        var existingPlate = _context.Motorcycles.Find(d => d.Plate == motoDto.Plate).FirstOrDefault();

        
        if (existingPlate != null)
        {
            return BadRequest(new { mensagem = "Placa já cadastrada." });
        }

        var moto = new Motorcycle
        {
            Identifier = motoDto.Identifier,
            Year = motoDto.Year,
            Model = motoDto.Model,
            Plate = motoDto.Plate
        };
        
        _context.Motorcycles.InsertOne(moto);
        return CreatedAtAction(nameof(GetForIdentifier), 
            new { id = moto.Identifier },
            moto);
    }
    
    
    /// <summary>
    /// Consultar motos existentes
    /// </summary>
    /// <param name="placa"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Retornara uma lista até 50 motos por paginação</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Motorcycle>))]
    public IEnumerable<Motorcycle> GetMotors([FromQuery] string plate = "")
    {
        var filter = string.IsNullOrEmpty(plate) 
            ? Builders<Motorcycle>.Filter.Empty
            : Builders<Motorcycle>.Filter.Eq(m => m.Plate, plate);

        return _context.Motorcycles.Find(filter).ToList();
    }
    
    /// <summary>
    /// Modificar a placa de uma moto
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso seja válido placa modificada com sucesso</response>
    /// <response code="404">Caso não seja válido</response>
    /// <response code="400">Caso não seja válido</response>
    [HttpPut("{id}/placa")]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    public IActionResult PutMotorcycle(string id, [FromBody] UpdateMotoDto motoDto)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest(new { mensagem = "Dados inválidos" });
        }
        
        var moto = _context.Motorcycles.Find(m => m.Identifier == id).FirstOrDefault();
        if (moto == null) return NotFound(new { message = "Moto não encontrada" });
        
        moto.Plate = motoDto.Plate;
        
        _context.Motorcycles.ReplaceOne(m => m.Identifier == id, moto);
        return Ok(new { message = "Placa atualizada" });
    }
    
    
    /// <summary>
    /// Consultar motos existentes por id
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Detalhes da moto</response>
    /// <response code="404">Moto não encontrada</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    public IActionResult GetForIdentifier(string id)
    {
        
        
       var moto =  _context.Motorcycles.Find(m => m.Identifier == id).FirstOrDefault();
       if (moto == null)
       {
           return NotFound(new { mensagem = "Moto não encontrada." });
       }

       var readMotoDto = new ReadMotoDto
       {
           Identifier = moto.Identifier,
           Year = moto.Year,
           Model = moto.Model,
           Plate = moto.Plate
       };
       
       return Ok(readMotoDto);
    }
    

    /// <summary>
    /// Remover uma moto
    /// </summary>
    /// <param name="skip"></param>
    /// <param name="take"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200"></response>
    /// <response code="400">Dados inválidos</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    
    public IActionResult DeleteMotorcycle(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest(new { mensagem = "Dados inválidos" });
        }
        
        var deleteResult = _context.
            Motorcycles.DeleteOne(m => m.Identifier == id);
        if (deleteResult.DeletedCount == 0)
        {
            return NotFound(new { message = "Moto não encontrada" });
        }
        
        return Ok();
    }


    
}
