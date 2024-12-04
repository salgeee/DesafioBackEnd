using System;

namespace MotoRentalApp.Data.DTOs;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

public class CreateDeliveryManDto
{
    
    [Required(ErrorMessage = "Identifier is required")]
    [MaxLength(50, ErrorMessage = "Identifier cannot exceed 50 characters.")]
    public string Identifier { get; set; } 
    
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "CNPJ is required")]
    [MaxLength(14, ErrorMessage = "CNPJ cannot exceed 14 characters.")]
    public string cnpj { get; set; }
    
    [Required(ErrorMessage = "Birth Date is required")]
    public DateTime birth_date { get; set; }
    
    [Required(ErrorMessage = "CNH Number is required")]
    [MaxLength(11, ErrorMessage = "CNH Number cannot exceed 11 characters.")]
    public string cnh_number { get; set; }
    
    [Required(ErrorMessage = "CNH Type is required")]
    [MaxLength(4, ErrorMessage = "CNH Type cannot exceed 4 characters.")]
    [RegularExpression(@"^(A|B|A\+B)$", ErrorMessage = "CNH type must be 'A', 'B', or 'A+B'.")]
    public string cnh_type { get; set; }
    
    public string image_cnh { get; set; }
}