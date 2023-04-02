using Akanay.Core.Entities;

namespace Akanay.Entities.Models
{
    public class Category:IEntity
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
