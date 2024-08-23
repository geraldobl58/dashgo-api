using dashgo_api.Data;
using dashgo_api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace dashgo_api.Repositories
{
    public class SQLPropertyRepository : IPropertyRepository
    {
        private readonly DashgoDbContext dbContext;

        public SQLPropertyRepository(DashgoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Property> CreateAsync(Property property)
        {
            await dbContext.Properties.AddAsync(property);
            await dbContext.SaveChangesAsync();

            return property;
        }

        public async Task<Property?> DeleteAsync(Guid id)
        {
            var exists = await dbContext.Properties.FirstOrDefaultAsync(x => x.Id == id);

            if (exists == null)
            {
                return null;
            }

            dbContext.Properties.Remove(exists);

            await dbContext.SaveChangesAsync();

            return exists;
        }

        public async Task<List<Property>> GetAllAsync(string? title = null, string? category = null, int? bathroom = null, int pageNumber = 1, int pageSize = 10)
        {
            var property = dbContext.Properties.AsQueryable();

            if (string.IsNullOrWhiteSpace(title) == false)
            {
                property = property.Where(x => x.Title.Contains(title));
            }

            if (string.IsNullOrWhiteSpace(category) == false)
            {
                property = property.Where(x => x.Category.Contains(category));
            }

            if (string.IsNullOrWhiteSpace(bathroom.ToString()) == false)
            {
                property = property.Where(x => x.Bathroom.ToString().Contains(bathroom.ToString()));
            }

            var totalItems = await property.CountAsync();


            var produtos = await property
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return Ok(new
            {
                Data = produtos,
                TotalItems = totalItems,
                Page = pageNumber,
                PageSize = pageSize
            });
        }

        public async Task<Property?> GetByIdAsync(Guid id)
        {
            return await dbContext.Properties.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Property?> UpdateAsync(Guid id, Property property)
        {
            var exists = await dbContext.Properties.FirstOrDefaultAsync(x => x.Id == id);

            if (exists == null) 
            {
                return null;
            }

            exists.Title = property.Title;
            exists.Description = property.Description;
            exists.Address = property.Address;
            exists.Neighborhood = property.Neighborhood;
            exists.Price = property.Price;
            exists.Size = property.Size;
            exists.Bathroom = property.Bathroom;
            exists.Bedroom = property.Bedroom;
            exists.Garage = property.Garage;

            await dbContext.SaveChangesAsync();

            return exists;
        }
    }
}
