using System;

namespace MotoRentalApp.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

public class CreateLocationDto
{
    
    [Required(ErrorMessage = "Identifier é necessário")]
    [MaxLength(50, ErrorMessage = "Identifier DeliveryMan não pode exceder 50 caracteres.")]
    public string Id_deliveryman { get; set; } 
    
    [Required(ErrorMessage = "Id_motor é necessário")]
    [MaxLength(50, ErrorMessage = "Identifier Motor não pode exceder 50 caracteres.")]
    public string Id_motor { get; set; }
    
    [Required(ErrorMessage = "Start Date é necessário")]
    public DateTime start_date { get; set; }
    
    [Required(ErrorMessage = "End Date é necessário")]
    public DateTime end_date { get; set; }
    
    [Required(ErrorMessage = "End Forecaste Date é necessário")]
    public DateTime end_forecast_date { get; set; }
    
    [Required(ErrorMessage = "Plan é necessário")]
    public int plan { get; set; }
    
}