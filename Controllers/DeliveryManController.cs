using MongoDB.Driver;
using MotoRentalApp.Data;
using MotoRentalApp.Data.DTOs;
using MotoRentalApp.Models;

namespace MotoRentalApp.Controllers;
using Microsoft.AspNetCore.Mvc;
    
[ApiController]
[Route("entregadores")]

public class DeliveryManController : ControllerBase
{
    private readonly DeliveryManContext _context;

    public DeliveryManController(DeliveryManContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Cadastrar um novo entregador
    /// </summary>
    /// <param name="motoDto">Objeto com os campos necessários para cadastrar uma nova moto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201"> Caso a moto seja cadastrada com sucesso</response>
    /// <response code="400"> Dados inválidos</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)] 
    public IActionResult AddDeliveryMan([FromBody] CreateDeliveryManDto deliveryManDto)
    {
        
        var existingCnpj = _context.DeliveryMan.Find(d => d.cnpj == deliveryManDto.cnpj).FirstOrDefault();

        var existingCnhNumber = _context.DeliveryMan.Find(d => d.cnh_number == deliveryManDto.cnh_number).FirstOrDefault();

        if (existingCnpj != null)
        {
            return BadRequest(new { mensagem = "CNPJ já cadastrado." });
        }
        
        if (existingCnhNumber != null)
        {
            return BadRequest(new { mensagem = "Número da CNH já cadastrado." });
        }
        
        var deliveryMan = new DeliveryMan
        {
            Identifier = deliveryManDto.Identifier,
            Name = deliveryManDto.Name,
            cnpj = deliveryManDto.cnpj,
            birth_date = deliveryManDto.birth_date,
            cnh_number = deliveryManDto.cnh_number,
            cnh_type = deliveryManDto.cnh_type,
            image_cnh = deliveryManDto.image_cnh
        };
        
        _context.DeliveryMan.InsertOne(deliveryMan);

        
        return Created("", deliveryMan);
    }
    
    
    /// <summary>
    /// Enviar a foto da CNH
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso seja válido placa modificada com sucesso</response>
    /// <response code="404">Caso não seja válido</response>
    /// <response code="400">Caso não seja válido</response>
    [HttpPut("{id}/cnh")]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    public IActionResult PutDeliveryManCnh(string id, [FromBody] UpdateDeliveryManDto deliveryManDto)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest(new { mensagem = "Dados inválidos" });
        }
        
        var deliveryMan = _context.DeliveryMan.Find(m => m.Identifier == id).FirstOrDefault();
        if (deliveryMan == null) return NotFound(new { message = "Motorcycle not found" });
        
        deliveryMan.image_cnh = deliveryManDto.image_cnh;
        
        _context.DeliveryMan.ReplaceOne(m => m.Identifier == id, deliveryMan);
        return Ok(new { message = "Image CNH updated" });
    }
    
    
}
