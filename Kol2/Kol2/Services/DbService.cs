using Kol2.Context;
using Kol2.DTOs;
using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Services;

public class DbService : IDbService
{
    private readonly MyDbContext _context;

    public DbService(MyDbContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesCharacterExist(int characterId)
    {
        return await _context.Characters.AnyAsync(c => c.Id == characterId);
    }

    public async Task<ICollection<Character>> GetCharactersData(int characterId)
    {
        return await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b => b.Item)
            .Include(c => c.CharactersTitles)
            .ThenInclude(ct => ct.Title)
            .Where(c => c.Id == characterId)
            .ToListAsync();
    }

    public async Task<bool> DoesItemExist(int itemId)
    {
        return await _context.Items.AnyAsync(i => i.Id == itemId);
    }

    public async Task<Item> GetItem(int itemId)
    {
        return await _context.Items.FirstAsync(i => i.Id == itemId);
    }

    public async Task<Character> GetCharacter(int characterId)
    {
        return await _context.Characters.FirstAsync(c => c.Id == characterId);
    }

    public async Task AddItemsToBackPack(List<NewItemsDTO> items, int characterId)
    {
        var itemsAmount = new Dictionary<int, int>();
        foreach (var item in items)
        {
            if (itemsAmount.Keys.Contains(item.Id))
            {
                itemsAmount[item.Id]++;
            }
            else
            {
                itemsAmount.Add(item.Id, 1);
            }
        }

        foreach (var itemAmount in itemsAmount.Keys)
        {
            for (var i = 0; i < itemsAmount[itemAmount]; i++)
            {
                var item = await GetItem(itemAmount);
            }
        }
    }
}