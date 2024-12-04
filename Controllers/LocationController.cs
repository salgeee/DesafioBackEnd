using System;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using MotoRentalApp.Data;
using MotoRentalApp.Data.DTOs;
using MotoRentalApp.Models;

namespace MotoRentalApp.Controllers;
using Microsoft.AspNetCore.Mvc;
    
[ApiController]
[Route("locacao")]
[Tags("Locação")]
public class LocationController : ControllerBase
{
    private readonly LocationContext _context;
    private readonly DeliveryManContext _deliveryManContext;

    public LocationController(LocationContext context, DeliveryManContext deliveryManContext)
    {
        _context = context;
        _deliveryManContext = deliveryManContext;
    }
    
    
    /// <summary>
    /// Cadastrar um novo entregador
    /// </summary>
    /// <param name="locationDto">Objeto com os campos necessários para cadastrar uma nova locação</param>
    /// <returns>IActionResult</returns>
    /// <response code="201"> Caso a locação seja cadastrada com sucesso</response>
    /// <response code="400"> Dados inválidos</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)] 
    public IActionResult AddLocation([FromBody] CreateLocationDto locationDto)
    {
        
        var deliveryman = _deliveryManContext.DeliveryMan.Find(d => d.Identifier == locationDto.Id_deliveryman).FirstOrDefault();
        if (deliveryman == null)
        {
            return BadRequest(new { mensagem = "Entregador não encontrado." });
        }
        
        var validPlans = new[] { 7, 15, 30, 45, 50 };
        if (!validPlans.Contains(locationDto.plan))
        {
            return BadRequest(new { mensagem = "Plano inválido. Planos válidos são: 7, 15, 30, 45, 50 dias." });
        }
        
        var startDate = DateTime.UtcNow.AddDays(1);
        var endForecastDate = startDate.AddDays(locationDto.plan);
        
        var totalLocations = _context.Location.CountDocuments(_ => true); // Conta o número de locações existentes
        var identifier = $"locacao{totalLocations + 1}";
        
        var location = new Location 
        {
            Identifier = identifier,
            Id_motor = locationDto.Id_motor,
            Id_deliveryman = locationDto.Id_deliveryman,
            start_date = startDate,
            end_date = locationDto.end_date,
            end_forecast_date = endForecastDate,
            plan = locationDto.plan
        };
        
        _context.Location.InsertOne(location);

        return CreatedAtAction(nameof(GetLocationById), new { id = location.Identifier }, location);
    }
    
    
    /// <summary>
    /// Consultar locações existentes por id
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Detalhes da Locação</response>
    /// <response code="404">Locação não encontrada</response>
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    public IActionResult GetLocationById(string id)
    {
        var location = _context.Location.Find(m => m.Identifier == id).FirstOrDefault();
        if (location == null)
        {
            return NotFound(new { mensagem = "Locação não encontrada." });
        }

        var locacaoDto = new ReadLocationDto
        {
            Identifier = location.Identifier,
            Id_deliveryman = location.Id_deliveryman,
            Id_motor = location.Id_motor,
            start_date = location.start_date,
            end_date = location.end_date,
            end_forecast_date = location.end_forecast_date,
            plan = location.plan
        };

        return Ok(locacaoDto);
    }
    
    
    /// <summary>
    /// Informar a data da devolução e calcular valor
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso seja válido calcula o valor</response>
    /// <response code="404">Caso não seja válido</response>
    /// <response code="400">Caso não seja válido</response>
    [HttpPut("{id}/devolucao")]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    public IActionResult PutLocation(string id, [FromBody] UpdateLocationReturnDto locationDto)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest(new { mensagem = "Dados inválidos" });
        }
        
        var location = _context.Location.Find(m => m.Identifier == id).FirstOrDefault();
        if (location == null) return NotFound(new { message = "Locação não encontrada." });
        
        location.return_date = locationDto.return_date;
        
        
        var deliveryman = _deliveryManContext.DeliveryMan.Find(d => d.Identifier == location.Id_deliveryman).FirstOrDefault();

        if (deliveryman == null || deliveryman.cnh_type != "A")
        {
            return BadRequest(new
                { mensagem = "Somente entregadores habilitados na categoria A podem contratar uma locação" });
        }
        
        
        location.return_date = locationDto.return_date;
        
        var rentalDays = (location.return_date - location.start_date).Days;
        if (rentalDays < 0)
        {
            return BadRequest(new { mensagem = "Data de devolução inválida." });
        }
        
        int costPerDay = location.plan switch
        {
            7 => 30,
            15 => 28,
            30 => 22,
            45 => 20,
            50 => 18,
            _ => throw new Exception("Plano de locação inválido") // Validação adicional
        };
        
        double totalCost  = rentalDays * costPerDay;
        
        if (location.return_date < location.end_forecast_date)
        {
            var missedDays = (location.end_forecast_date - location.return_date).Days;
            var penaltyRate = location.plan switch
            {
                7 => 0.2,
                15 => 0.4,
                _ => 0.0
            };
            var penalty = missedDays * costPerDay * penaltyRate;
            totalCost += penalty; 
        }
        
       
        if (location.return_date > location.end_forecast_date)
        {
            var extraDays = (location.return_date - location.end_forecast_date).Days;
            var extraCost = extraDays * 50;
            totalCost += extraCost;
        }
        
        
        _context.Location.ReplaceOne(m => m.Identifier == id, location);
        return Ok(new
        {
            message = "Data de devolução atualizada",
            custo_total = totalCost,
            dias_alugados = rentalDays
        });
    }
    
    
}
