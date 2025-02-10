using InventorySystem.DTOs;
using InventorySystem.Models;
using InventorySystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers;


[ApiController]
[Route("inventory-system/api/users")]
public class MachineController : ControllerBase
{
    private readonly IMachineRepository _repository;

    public MachineController(IMachineRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    [Route("create-machine")]
    public async Task<IActionResult> CreateAsync(MachineDTO machineDto)
    {
        var machine = new Machine
        {
            Name = machineDto.Name,
            Description = machineDto.Description,
            RamMemory = machineDto.RamMemory,
            Processor = machineDto.Processor,
            Tag = machineDto.Tag,
            RomMemory = machineDto.RomMemory,
            UserId = machineDto.UserId
        };
        
        await _repository.AddMachineAsync(machine);

        return Ok(machineDto);
    }


    [HttpGet]
    [Route("get-machine")]

    public async Task<IActionResult> GetMachineAsync([FromQuery] Guid? machineId)
    {
        if (machineId.HasValue)
        {
            var machine = await _repository.GetByIdAsync(machineId.Value);
            return Ok(machine);
        }
        
        var machines = await _repository.GetAllAsync();
        return Ok(machines);
    }
    


    [HttpPut]
    [Route("update-machine")]
    public async Task<IActionResult> UpdateMachineAsync(Guid id, MachineDTO machineDto)
    {
        var machine = await _repository.GetByIdAsync(id);
        
        machine.Name = machineDto.Name;
        machine.Description = machineDto.Description;
        machine.RamMemory = machineDto.RamMemory;
        machine.Processor = machineDto.Processor;
        machine.Tag = machineDto.Tag;
        machine.RomMemory = machineDto.RomMemory;
        machine.UserId = machineDto.UserId;
        
        await _repository.UpdateMachineAsync(machine);
        return Ok(machineDto);
    }


    [HttpDelete]
    [Route("delete-machine")]
    public async Task<IActionResult> DeleteMachineAsync(Guid id)
    {
        var machine = await _repository.GetByIdAsync(id);
        await _repository.DeleteMachineAsync(id);
        return NoContent();
    }
}