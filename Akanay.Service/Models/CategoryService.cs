using Akanay.Core.Utilities.Results.Interfaces;
using Akanay.Core.Utilities.Results.Models;
using Akanay.Entities.Models;
using Akanay.Repository.Interfaces;
using Akanay.Repository.Models.EntityFramework;
using Akanay.Service.Interfaces;
using Akanay.Service.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akanay.Service.Models
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IProductRepository _productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public IDataResult<Category> Add(Category category)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Add(category));
        }

        public IResult Delete(Category category)
        {
            foreach (var item in _productRepository.GetAll(p => p.CategoryId == category.CategoryId))
            {
                _productRepository.Delete(item);
                 new SuccessResult(Messages.ProductDeleted);
            }

            _categoryRepository.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryRepository.GetAll().ToList());
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Get(p => p.CategoryId == id));
        }

        public IDataResult<Category> Update(Category category)
        {
            return new SuccessDataResult<Category>(_categoryRepository.Update(category));
        }
    }
}
