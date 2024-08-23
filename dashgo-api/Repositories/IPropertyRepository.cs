using dashgo_api.Models.Domain;

namespace dashgo_api.Repositories
{
    public interface IPropertyRepository
    {
        Task<Property> CreateAsync(Property property);
        Task<List<Property>> GetAllAsync(
            string? title = null, 
            string? category = null,
            int? bathroom = null,
            int pageNumber = 1, 
            int pageSize = 10
        );
        Task<Property?> GetByIdAsync(Guid id);
        Task<Property?> UpdateAsync(Guid id, Property property);
        Task<Property?> DeleteAsync(Guid id);
    }
}
