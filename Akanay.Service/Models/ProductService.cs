﻿using Akanay.Core.Aspects.Autofac.Caching;
using Akanay.Core.Aspects.Autofac.Logging;
using Akanay.Core.Aspects.Autofac.Performance;
using Akanay.Core.Aspects.Autofac.Transaction;
using Akanay.Core.Aspects.Autofac.Validation;
using Akanay.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Akanay.Core.Utilities.Results.Interfaces;
using Akanay.Core.Utilities.Results.Models;
using Akanay.Entities.Models;
using Akanay.Repository.Interfaces;
using Akanay.Service.Interfaces;
using Akanay.Service.ServiceAspects.Autofac;
using Akanay.Service.Statics;
using Akanay.Service.ValidationRules.FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        [LogAspect(typeof(FileLogger))]
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productRepository.Get(p => p.ProductID == id));
        }

        [PerformanceAspect(2)]
        public IDataResult<List<Product>> GetAll()
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll().ToList());
        }

        //[SecureOperation("Product.List,Admin")]
        [CacheAspect(duration:10)]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productRepository.GetAll(p => p.CategoryId == categoryId).ToList());
        }


        [ValidationAspect(typeof(ProductValidator),Priority =1) ]
        [CacheRemoveAspect("IProductService.Get")]
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

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
           _productRepository.Update(product);
            //_productRepository.Add(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
