namespace Kol2.DTOs;

public class GetCharactersDataDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    public ICollection<GetBackpackItemsDTO> BackpackItems { get; set; } = null!;
    public ICollection<GetTitlesDTO> Titles { get; set; } = null!;
}