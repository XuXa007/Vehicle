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
    
    public List<MaintenanceTask> MaintenanceTasks { get; set; }
}
// dotnet ef migrations add InitialCreate
// dotnet ef database update
// dotnet ef migrations add YourMigrationName
// dotnet ef database update
// SecondCreateBD