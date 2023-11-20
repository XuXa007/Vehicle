using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;


// [Table("registerViewModel")]

public class RegisterViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [MinLength(3, ErrorMessage = "Password must be at least 3 characters.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}