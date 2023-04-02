using Akanay.Core.Utilities.Results.Interfaces;
using Akanay.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Service.Interfaces
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IDataResult<Category> Add(Category category);
        IDataResult<Category> Update(Category category);
        IResult Delete(Category category);
    }
}
