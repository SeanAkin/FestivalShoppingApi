using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.RequestModels;

namespace FestivalShoppingApi.Domain.Contracts;

public interface ICategoryService
{
   Task<Result> CreateCategory(Guid guid, NewCategoryRequest categoryToAdd);
   Task<Result> DeleteCategory(Guid guid);
}