namespace MotoRentalApp.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

public class CreateLocationDto
{
    
    [Required(ErrorMessage = "Identifier is required")]
    [MaxLength(50, ErrorMessage = "Identifier DeliveryMan cannot exceed 50 characters.")]
    public string Id_deliveryman { get; set; } 
    
    [Required(ErrorMessage = "Id_motor is required")]
    [MaxLength(50, ErrorMessage = "Identifier Motor cannot exceed 50 characters.")]
    public string Id_motor { get; set; }
    
    [Required(ErrorMessage = "Start Date is required")]
    public DateTime start_date { get; set; }
    
    [Required(ErrorMessage = "End Date is required")]
    public DateTime end_date { get; set; }
    
    [Required(ErrorMessage = "End Forecaste Date is required")]
    public DateTime end_forecast_date { get; set; }
    
    [Required(ErrorMessage = "Plan is required")]
    public int plan { get; set; }
    
}