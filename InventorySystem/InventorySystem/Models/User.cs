using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models;

public class User
{
    
    [Key]
    public Guid Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Name { get; set; }
    
    [Required, MaxLength(50)]
    public bool Active { get; set; }
    
    [Required]
    public bool AssignTerm { get; set; }
    
    [Required]
    public DateOnly OnboardDate { get; set; }
    
    [Required, MaxLength(100)]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    
    public Guid? MachineId { get; set; }
    
    [ForeignKey("MachineId")]
    public Machine Machine { get; set; }
}