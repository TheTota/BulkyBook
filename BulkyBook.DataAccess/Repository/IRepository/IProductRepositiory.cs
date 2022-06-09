using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj); // Update is specific to each model, so it is part of this interface and not IRepository
    }
}
