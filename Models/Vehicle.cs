using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models;

[Table("vehicle")]

public class Vehicle
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string RegistrationNumber { get; set; }
    
    
    public ICollection<MaintenanceTask> MaintenanceTasks { get; set; }
}