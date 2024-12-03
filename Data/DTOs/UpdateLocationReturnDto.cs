using System.ComponentModel.DataAnnotations;

namespace MotoRentalApp.Data.DTOs;

public class UpdateLocationReturnDto
{
    [Required(ErrorMessage = "Return Date is required")]
    public DateTime return_date { get; set; }
}