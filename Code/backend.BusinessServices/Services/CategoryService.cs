using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _CategoryRepository;

        public CategoryService(ICategoryRepository CategoryRepository)
        {
           this._CategoryRepository = CategoryRepository;
        }
        public IEnumerable<Category> GetAll()
        {
            return _CategoryRepository.GetAll();
        }

        public Category Get(string id)
        {
            return _CategoryRepository.Get(id);
        }

        public Category Save(Category category)
        {
            _CategoryRepository.Save(category);
            return category;
        }

        public Category Update(string id, Category category)
        {
            return _CategoryRepository.Update(id, category);
        }

        public bool Delete(string id)
        {
            return _CategoryRepository.Delete(id);
        }

    }
}
