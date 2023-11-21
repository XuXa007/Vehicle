using WebApplication3.Models;

namespace WebApplication3.Services;

public class MaintenanceService : IMaintenanceService
{
    private readonly List<MaintenanceRequest> _maintenanceRequests = new List<MaintenanceRequest> { new MaintenanceRequest { Id = 1 } };

    public List<MaintenanceRequest> GetMaintenanceRequests()
    {
        // Возвращаем реальные данные или что-то еще
        return _maintenanceRequests;
    }
    public void CreateMaintenanceRequest(string vehicleName, string description)
    {
        var newRequest = new MaintenanceRequest
        {
            Id = _maintenanceRequests.Count + 1,
            VehicleName = vehicleName,
            Description = description,
            RequestDate = DateTime.Now,
            IsCompleted = false
        };

        _maintenanceRequests.Add(newRequest);
    }
}

