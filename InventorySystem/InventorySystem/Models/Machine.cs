using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Models;

public class Machine
{
    
    [Key]
    public Guid Id { get; set; }
    
    [Required, MaxLength(50)]
    public required string Name { get; set; }
    
    [Required, MaxLength(500)]
    public required string Description { get; set; }
    
    [Required]
    public int RamMemory { get; set; }
    
    [Required]
    public string Processor { get; set; }
    
    [Required]
    public int RomMemory { get; set; }
    
    
    
    
    public Guid? UserId { get; set; }
    
    [ForeignKey("UserId")]
    public User User { get; set; }
}