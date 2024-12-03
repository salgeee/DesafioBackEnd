namespace MotoRentalApp.Data.DTOs;
using System.ComponentModel.DataAnnotations;

public class UpdateLocationDto
{
 
    [Required(ErrorMessage = "End Forecast Date is required")]
    public DateTime end_forecast_date { get; set; }
}