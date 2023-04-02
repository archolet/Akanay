using Akanay.Core.Entities;

namespace Akanay.Entities.Models
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitStock { get; set; }

    }
}
