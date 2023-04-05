using Akanay.Core.Utilities.Results.Interfaces;
using Akanay.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Service.Interfaces
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<Product> GetById(int id);
        IDataResult<List<Product>> GetListByCategory(int categoryId);
        IDataResult<Product> Add(Product product);
        IDataResult<Product> Update(Product product);
        IResult Delete(Product product);

        IResult TransactionalOperation(Product product);

    }
}
