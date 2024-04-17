using FestivalShoppingApi.Data.RequestModels;

namespace FestivalShoppingApi.Domain.Contracts;

public interface ICategoryService
{
   Task<bool> CreateCategory(Guid guid, NewCategoryRequest categoryToAdd);
}