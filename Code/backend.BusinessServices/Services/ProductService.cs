using backend.BusinessServices.Interfaces;
using backend.Data.Interfaces;
using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.BusinessServices.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _ProductRepository;

        public ProductService(IProductRepository ProductRepository)
        {
           this._ProductRepository = ProductRepository;
        }
        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public Product Get(string id)
        {
            return _ProductRepository.Get(id);
        }

        public Product Save(Product product)
        {
            _ProductRepository.Save(product);
            return product;
        }

        public Product Update(string id, Product product)
        {
            return _ProductRepository.Update(id, product);
        }

        public bool Delete(string id)
        {
            return _ProductRepository.Delete(id);
        }

    }
}
