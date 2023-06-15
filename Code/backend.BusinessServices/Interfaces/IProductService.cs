using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Interfaces
{
    public interface IProductService
    {      
        IEnumerable<Product> GetAll();
        Product Get(string id);
        Product Save(Product product);
        Product Update(string id, Product product);
        bool Delete(string id);

    }
}
