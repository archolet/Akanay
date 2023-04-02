using Akanay.Core.Utilities.Results.Interfaces;
using Akanay.Core.Utilities.Results.Models;
using Akanay.Entities.Models;
using Akanay.Repository.Interfaces;
using Akanay.Service.Interfaces;
using Akanay.Service.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Service.Models
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productRepository.Get(p => p.ProductID == id));
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll().ToList());
        }

        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(p => p.CategoryId == categoryId).ToList());
        }


        public IDataResult<Product> Add(Product product)
        {
            return new SuccessDataResult<Product>(_productRepository.Add(product));
        }

        public IResult Delete(Product product)
        {
            _productRepository.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IDataResult<Product> Update(Product product)
        {
            return new SuccessDataResult<Product>(_productRepository.Update(product));
        }
    }
}
