using InventorySystem.DTOs;
using InventorySystem.Models;
using InventorySystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers;


[ApiController]
[Route("inventory-system/api/machines")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [Route("create-user")]
    public async Task<IActionResult> CreateAsync(UserDTO userDto)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            Name = userDto.Name,
            Active = userDto.Active,
            OnboardDate = userDto.OnboardDate,
            Email = userDto.Email,
            Password = userDto.Password,
            MachineId = userDto.MachineId
        };

        await _userRepository.AddUserAsync(user);
        
        return Ok(userDto);
    }



    [HttpGet]
    [Route("get-user")]

    public async Task<IActionResult> GetUserAsync([FromQuery] Guid? id)
    {
        if (id.HasValue)
        {
            var user = await _userRepository.GetUserByIdAsync(id.Value);
            return Ok(new UserDTO()
            {
                Name = user.Name,
                Active = user.Active,
                AssignTerm = user.AssignTerm,
                OnboardDate = user.OnboardDate,
                Email = user.Email,
                MachineId = user.MachineId
            });
        }
        
        var users = await _userRepository.GetUsersAsync();
        return Ok(users.Select(x => new UserDTO()
        {
            Name = x.Name,
            Active = x.Active,
            AssignTerm = x.AssignTerm,
            OnboardDate = x.OnboardDate,
            Email = x.Email,
            MachineId = x.MachineId
        }));
    }

    [HttpPut]
    [Route("update-user")]
    public async Task<IActionResult> UpdateAsync(Guid id, UserDTO userDto)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        
        user.Name = userDto.Name;
        user.Active = userDto.Active;
        user.OnboardDate = userDto.OnboardDate;
        user.Email = userDto.Email;
        user.Password = userDto.Password;
        user.MachineId = userDto.MachineId;
        
        await _userRepository.UpdateUserAsync(user);
        return Ok(user);
    }

    [HttpDelete]
    [Route("delete-machine")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        await _userRepository.DeleteUserAsync(user);
        return NoContent();
    }
    
    
    
}