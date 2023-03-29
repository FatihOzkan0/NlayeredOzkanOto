using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;        //BU ŞEKİLDE ERİŞEREK INTERFACEDEN NEW LEMEMİŞİZ OLUYORUZ.

        public CategoryManager(ICategoryDal categoryDal) 
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public List<Category> CategorySearch(string CategoryName)
        {
           return _categoryDal.GetAll(P=>P.CategoryName.Contains(CategoryName));        //Contains :Parametre olarak alınan string değerinin, ilgili string içinde olup olmadığını gösterir.
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> Listele()
        {
            return _categoryDal.GetAll();
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
