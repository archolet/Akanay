using Akanay.Core.Repository.EntityFramework;
using Akanay.Entities.Models;
using Akanay.Repository.Interfaces;
using Akanay.Repository.Models.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Repository.Models.EntityFramework
{
    public class EfCategoryRepository : EfEntitiyRepository<Category, DatabaseContext>, ICategoryRepository
    {
    }
}
