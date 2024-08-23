using Bogus;
using dashgo_api.Data;
using dashgo_api.Models.Domain;
using Microsoft.EntityFrameworkCore;


public class DatabaseSeeder
{
    private readonly DashgoDbContext _context;

    public DatabaseSeeder(DashgoDbContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (await _context.Properties.AnyAsync())
        {
            return; // DB has already been seeded
        }

        var faker = new Faker<Property>()
            .RuleFor(e => e.Id, f => new Guid())
            .RuleFor(e => e.Title, f => f.Name.FullName())
            .RuleFor(e => e.Category, f => f.Commerce.Department())
            .RuleFor(e => e.Description, f => f.Lorem.Paragraph())
            .RuleFor(e => e.Address, f => f.Address.StreetAddress())
            .RuleFor(e => e.Neighborhood, f => f.Address.State())
            .RuleFor(e => e.Price, f => f.Random.Number(10, 900))
            .RuleFor(e => e.Size, f => f.Random.Number(100, 900))
            .RuleFor(e => e.Bathroom, f => f.Random.Number(1, 5))
            .RuleFor(e => e.Bedroom, f => f.Random.Number(1, 5))
            .RuleFor(e => e.Garage, f => f.Random.Number(1, 5));
            

        var fakeEntities = faker.Generate(20); // Generate fake entities

        await _context.Properties.AddRangeAsync(fakeEntities);
        await _context.SaveChangesAsync();
    }
}