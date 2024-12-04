namespace MotoRentalApp.Data.DTOs;
using System.ComponentModel.DataAnnotations;

public class UpdateDeliveryManDto
{
 
    [Required(ErrorMessage = "Image CNH is required")]
    public IFormFile CnhImage { get; set; }
}