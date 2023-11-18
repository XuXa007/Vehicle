using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;

[Table("user")]

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Username is required.")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")] 
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required.")]
    [MinLength(3, ErrorMessage = "Password must be at least 3 characters.")]
    public string Password { get; set; }
    public string Role { get; set; }
    
    public ICollection<Report> Reports { get; set; }
}