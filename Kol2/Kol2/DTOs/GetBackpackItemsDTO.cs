namespace Kol2.DTOs;

public class GetBackpackItemsDTO
{
    public string ItemName { get; set; } = string.Empty;
    public int ItemWeight { get; set; }
    public int Amount { get; set; }
}