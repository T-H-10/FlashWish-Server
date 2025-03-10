using AutoMapper;
using FlashWish.Core.DTOs;
using FlashWish.Core.Entities;
using FlashWish.Core.IServices;
using FlashWish.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public CategoryDTO AddCategory(CategoryDTO category)
        {
            var categoryToAdd = _mapper.Map<Category>(category);
            if (category != null)
            {
                _repositoryManager.Categories.Add(categoryToAdd);
                _repositoryManager.Save();
            }
            return _mapper.Map<CategoryDTO>(categoryToAdd);
        }

        public bool DeleteCategory(int id)
        {
            var categoryDTO = _repositoryManager.Categories.GetByIdAsync(id);
            var categoryToDelete = _mapper.Map<Category>(categoryDTO);
            if (categoryToDelete == null) { return false; }
            _repositoryManager.Categories.Delete(categoryToDelete);
            _repositoryManager.Save();
            return true;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _repositoryManager.Categories.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category =await _repositoryManager.Categories.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public CategoryDTO? UpdateCategory(int id, CategoryDTO category)
        {
            if (category == null) return null;
            var categoryToUpdate = _mapper.Map<Category>(category);
            _repositoryManager.Categories.Update(id, categoryToUpdate);
            _repositoryManager.Save();
            return _mapper.Map<CategoryDTO?>(categoryToUpdate);
        }
    }
}
