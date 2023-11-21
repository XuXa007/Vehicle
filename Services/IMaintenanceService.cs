using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IMaintenanceService
{
    List<MaintenanceRequest> GetMaintenanceRequests();
    
    void CreateMaintenanceRequest (string vehicleName, string description);
}