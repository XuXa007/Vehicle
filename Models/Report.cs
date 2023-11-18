using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;


[Table("report")]

public class Report
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
}