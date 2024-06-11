using System.ComponentModel.DataAnnotations;

namespace Kol2.DTOs;

public class NewItemsDTO
{
    [Required]
    public int Id { get; set; }
}