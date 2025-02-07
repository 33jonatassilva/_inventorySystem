

using InventorySystem.Models;

namespace InventorySystem.Repositories.Interfaces;

public interface IMachineRepository
{

    Task<Machine> AddMachineAsync(Machine machine);
    Task<Machine> GetByIdAsync(Guid id);
    Task<IEnumerable<Machine>> GetAllAsync();
    Task<Machine> UpdateMachineAsync(Machine machine);
    Task DeleteMachineAsync(Guid id);

}