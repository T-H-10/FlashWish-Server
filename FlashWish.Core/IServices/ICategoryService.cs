using FlashWish.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Core.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO?> GetCategoryByIdAsync(int id);
        CategoryDTO AddCategory(CategoryDTO category);
        CategoryDTO? UpdateCategory(int id, CategoryDTO category);
        bool DeleteCategory(int id);
    }
}
