﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal) 
        {
          _productDal= productDal;
        }

        public void Add(Product product)
        {
             _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public List<Product> Listeler()
        {
            return _productDal.GetAll();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public List<Product> UrunArama(string ProductName)
        {
             return _productDal.GetAll(p=>p.ProductName.Contains(ProductName));
        }
    }
}
