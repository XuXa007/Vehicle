namespace WebApplication3.Models;

public class MaintenanceRequest
{
    public int Id { get; set; }
    public string VehicleName { get; set; }
    public string Description { get; set; }
    public DateTime RequestDate { get; set; }
    public bool IsCompleted { get; set; }
}