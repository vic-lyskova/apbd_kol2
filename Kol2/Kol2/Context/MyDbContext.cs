using Kol2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2.Context;

public class MyDbContext : DbContext
{
    protected MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new Item()
            {
                Id = 1,
                Name = "Name1",
                Weight = 10
            },
            new Item()
            {
                Id = 2,
                Name = "Name2",
                Weight = 20
            },
            new Item()
            {
                Id = 3,
                Name = "Name3",
                Weight = 30
            }
        });

        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new Backpack()
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 10
            },
            new Backpack()
            {
                CharacterId = 2,
                ItemId = 2,
                Amount = 20
            },
            new Backpack()
            {
                CharacterId = 3,
                ItemId = 3,
                Amount = 30
            }
        });

        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character()
            {
                Id = 1,
                FirstName = "FirstName1",
                LastName = "LastName1",
                CurrentWeight = 10,
                MaxWeight = 100
            },
            new Character()
            {
                Id = 2,
                FirstName = "FirstName2",
                LastName = "LastName2",
                CurrentWeight = 20,
                MaxWeight = 200
            },
            new Character()
            {
                Id = 3,
                FirstName = "FirstName3",
                LastName = "LastName3",
                CurrentWeight = 30,
                MaxWeight = 300
            }
        });

        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = new DateTime(2024, 12, 7)
            },
            new CharacterTitle()
            {
                CharacterId = 2,
                TitleId = 2,
                AcquiredAt = new DateTime(1909, 05, 6)
            },
            new CharacterTitle()
            {
                CharacterId = 3,
                TitleId = 3,
                AcquiredAt = new DateTime(1000, 5, 20)
            }
        });

        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title()
            {
                Id = 1,
                Name = "Name1"
            },
            new Title()
            {
                Id = 2,
                Name = "Name2"
            },
            new Title()
            {
                Id = 3,
                Name = "Name3"
            },
        });
    }
}