using Kol2.DTOs;
using Kol2.Models;

namespace Kol2.Services;

public interface IDbService
{
    Task<bool> DoesCharacterExist(int characterId);
    Task<ICollection<Character>> GetCharactersData(int characterId);
    Task<bool> DoesItemExist(int itemId);
    Task<Item> GetItem(int itemId);
    Task<Character> GetCharacter(int characterId);
    Task AddItemsToBackPack(List<NewItemsDTO> items, int characterId);
}