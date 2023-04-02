using Akanay.Core.Repository.EntityFramework;
using Akanay.Entities.Models;
using Akanay.Repository.Interfaces;
using Akanay.Repository.Models.EntityFramework.Contexts;

namespace Akanay.Repository.Models.EntityFramework
{
    public class EfProductRepository :EfEntitiyRepository<Product,DatabaseContext> ,IProductRepository
    {
     
    }
}
