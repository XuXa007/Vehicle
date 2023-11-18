using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;


[Table("maintenanceTask")]

public class MaintenanceTask
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    
    public int VehicleId { get; set; }
    [ForeignKey("VehicleId")]
    public Vehicle Vehicle { get; set; }
}