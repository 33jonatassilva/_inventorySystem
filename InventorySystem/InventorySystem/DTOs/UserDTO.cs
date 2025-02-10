using InventorySystem.Models;

namespace InventorySystem.DTOs;

public class UserDTO
{
    public string Name { get; set; }
    
    public bool Active { get; set; }
    
    public bool AssignTerm { get; set; }
    
    public DateOnly OnboardDate { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public Guid? MachineId { get; set; }
}