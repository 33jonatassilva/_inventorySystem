using System.Reflection.PortableExecutable;
using InventorySystem.Data;
using InventorySystem.Models;
using InventorySystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Machine = InventorySystem.Models.Machine;


namespace InventorySystem.Repositories;

public class MachineRepository : IMachineRepository
{
    
    private readonly AppDbContext _context;
    private IMachineRepository _machineRepositoryImplementation;

    public MachineRepository(AppDbContext context)
    {
        _context = context;
    }
    
    
    

    public async Task<Machine> AddMachineAsync(Machine machine)
    {
        await _context.Machines.AddAsync(machine);
        await _context.SaveChangesAsync();
        return machine;
    }
    
    public async Task<Machine> GetByIdAsync(Guid id)
    {
        var machine = await _context.Machines.FirstOrDefaultAsync(m => m.Id == id);
        
        if (machine == null)
            throw new KeyNotFoundException("Machine not found");
        
        return machine;
    }

    public async Task<IEnumerable<Machine>> GetAllAsync()
    {
        var machines = await _context.Machines.ToListAsync();
        return machines;
    }


    public async Task<Machine> UpdateMachineAsync(Machine machine)
    {
        _context.Entry(machine).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return machine;
    }


    public async Task DeleteMachineAsync(Guid id)
    {
        try
        {
            var machine = await _context.Machines.FirstOrDefaultAsync(m => m.Id == id);

            if (machine == null)
                throw new KeyNotFoundException("Machine not found");

            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
           throw new Exception($"Failed to delete machine {id}", e);
        }
        
        
    }
    
    
}