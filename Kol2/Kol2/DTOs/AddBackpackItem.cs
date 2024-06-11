using System.ComponentModel.DataAnnotations;

namespace Kol2.DTOs;

public class AddBackpackItem
{
    [Required]
    public int CharacterId { get; set; }
    [Required]
    public int ItemId { get; set; }
    [Required]
    public int Amount { get; set; }
}