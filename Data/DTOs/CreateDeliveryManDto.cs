using System;

namespace MotoRentalApp.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

public class CreateDeliveryManDto
{
    
    [Required(ErrorMessage = "Identifier é necessário")]
    [MaxLength(50, ErrorMessage = "Identifier cannot exceed 50 characters.")]
    public string Identifier { get; set; } 
    
    [Required(ErrorMessage = "Name é necessário")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "CNPJ é necessário")]
    [MaxLength(14, ErrorMessage = "CNPJ cannot exceed 14 characters.")]
    public string cnpj { get; set; }
    
    [Required(ErrorMessage = "Birth Date é necessário")]
    public DateTime birth_date { get; set; }
    
    [Required(ErrorMessage = "CNH Number é necessário")]
    [MaxLength(11, ErrorMessage = "CNH Number cannot exceed 11 characters.")]
    public string cnh_number { get; set; }
    
    [Required(ErrorMessage = "CNH Type é necessário")]
    [MaxLength(4, ErrorMessage = "CNH Type não pode execeder 4 caracteres.")]
    [RegularExpression(@"^(A|B|A\+B)$", ErrorMessage = "Tipo da CNH precisa ser 'A', 'B', or 'A+B'.")]
    public string cnh_type { get; set; }
    
    public string image_cnh { get; set; }
}