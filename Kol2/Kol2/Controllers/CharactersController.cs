using Kol2.DTOs;
using Kol2.Models;
using Kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kol2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly IDbService _dbService;

    public CharactersController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{characterId}")]
    public async Task<IActionResult> GetCharactersData(int characterId)
    {
        if (!await _dbService.DoesCharacterExist(characterId))
        {
            return NotFound($"Character with id {characterId} not found");
        }

        var characters = await _dbService.GetCharactersData(characterId);
        return Ok(characters.Select(c => new GetCharactersDataDTO()
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            CurrentWeight = c.CurrentWeight,
            MaxWeight = c.MaxWeight,
            BackpackItems = c.Backpacks.Select(b => new GetBackpackItemsDTO()
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount
            }).ToList(),
            Titles = c.CharactersTitles.Select(ct => new GetTitlesDTO()
            {
                Title = ct.Title.Name,
                AquiredAt = ct.AcquiredAt
            }).ToList()
        }).ToList());
    }

    [HttpPost("{characterId}/backpacks")]
    public async Task<IActionResult> AddItemsToBackpack(int characterId, List<NewItemsDTO> items)
    {
        if (!await _dbService.DoesCharacterExist(characterId))
        {
            return NotFound($"Character with id {characterId} not found");
        }

        var itemsToAdd = new List<Item>();
        
        foreach (var item in items)
        {
            if (!await _dbService.DoesItemExist(item.Id))
            {
                return NotFound($"Item with id {characterId} not found");
            }
            var itemToAdd = await _dbService.GetItem(item.Id);
            itemsToAdd.Add(itemToAdd);
        }

        var weightToAdd = itemsToAdd.Sum(i => i.Weight);

        var character = await _dbService.GetCharacter(characterId);

        if ((character.CurrentWeight + weightToAdd) > character.MaxWeight)
        {
            return BadRequest($"Character's with id {characterId} max weight was exceeded");
        }
        
        _dbService
    }
}