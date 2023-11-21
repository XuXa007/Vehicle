using WebApplication3.Models;

namespace WebApplication3.Services;

public interface IVehicleService
{
    Task<List<Vehicle>> GetVehiclesAsync();
    Task<Vehicle> GetVehicleByIdAsync(int id);
    Task AddVehicleAsync(Vehicle vehicle);
}