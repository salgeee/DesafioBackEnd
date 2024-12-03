namespace MotoRentalApp.Data.DTOs;
using System.ComponentModel.DataAnnotations;

public class UpdateMotoDto
{
 
    [Required(ErrorMessage = "Plate is required")]
    [MaxLength(10, ErrorMessage = "Max length for the plate is 10")]
    public string Plate { get; set; }
}