using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface ICategoryService
    {      
        IEnumerable<Category> GetAll();
        Category Get(string id);
        Category Save(Category category);
        Category Update(string id, Category category);
        bool Delete(string id);

    }
}
