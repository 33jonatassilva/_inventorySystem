namespace InventorySystem.DTOs;

public class MachineDTO
{
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public int RamMemory { get; set; }
    
    public string Processor { get; set; }
    
    public int Tag { get; set; }
    
    public int RomMemory { get; set; }
    
    public Guid? UserId { get; set; }

}