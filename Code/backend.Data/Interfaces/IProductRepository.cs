using backend.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Data.Interfaces
{
    public interface IProductRepository : IGetAll<Product>,IGet<Product,string>, ISave<Product>, IUpdate<Product, string>, IDelete<string>
    {
    }
}
