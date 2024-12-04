namespace MotoRentalApp.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

public class CreateMotoDto
{
    
    [Required(ErrorMessage = "Identifier é necessário")]
    [MaxLength(50, ErrorMessage = "Identifier não pode exceder 50 characters.")]
    public string Identifier { get; set; } 
    
    [Required(ErrorMessage = "Year é necessário")]
    public int Year { get; set; }
    
    [Required(ErrorMessage = "Model é necessário")]
    public string Model { get; set; }
    
    
    [Required(ErrorMessage = "Plate é necessário")]
    [MaxLength(10, ErrorMessage = "Tamanho máximo para plate é 10")]
    public string Plate { get; set; }
}