
using System.ComponentModel.DataAnnotations;

namespace MotoRentalApp.Models;

public class Motorcycle
{
    [Required(ErrorMessage = "Identifier is required")]
    [MaxLength(50, ErrorMessage = "Identifier cannot exceed 50 characters.")]
    public string Identifier { get; set; } 
    
    [Required(ErrorMessage = "Year is required")]
    public int Year { get; set; }
    
    [Required(ErrorMessage = "Model is required")]
    public string Model { get; set; }
    
    
    [Required(ErrorMessage = "Plate is required")]
    [MaxLength(10, ErrorMessage = "Max length for the plate is 10")]
    public string Plate { get; set; }
}