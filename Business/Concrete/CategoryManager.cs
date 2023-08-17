using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        IProductService _productService;
        public CategoryManager(ICategoryDal categoryDal,IProductService productService)
        {
            _categoryDal = categoryDal;
            _productService = productService;
        }
        
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Add(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameAlreadyExists(category.CategoryName));
            if (result != null) return result;

            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAddedSuccessfully);
        }

        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Delete(int categoryId)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryIsNotEmpty(categoryId));
            if (result != null) return result;

            Category categoryToDelete = _categoryDal.Get(c => c.CategoryID == categoryId);
            _categoryDal.Delete(categoryToDelete);
            return new SuccessResult(Messages.CategoryRemovedSuccessfully);
        }

        [CacheRemoveAspect("ICategoryService.Get")]
        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Update(Category category)
        {
            IResult result = BusinessRules.Run(CheckIfCategoryNameAlreadyExists(category.CategoryName));
            if (result != null) return result;

            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdatedSuccessfully);
        }

        [CacheAspect]
        public IDataResult<List<Category>> GetAllCategory()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);
        }

        public IDataResult<Category> GetCategoryByCategoryId(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryID == categoryId));
        }
        public IDataResult<Category> GetByCategoryName(string categoryName)
        {
            var categories = _categoryDal.GetAll();
            
            foreach (var category in categories)
            {
                if (category.CategoryName.ToLower() == categoryName.ToLower())
                {
                    return new SuccessDataResult<Category>(category);
                }
            }
            return new ErrorDataResult<Category>(Messages.CategoryNameNotFound);
        }
        
        //Kısıtlamalar
        private IResult CheckIfCategoryIsNotEmpty(int categoryId)
        {
            // Eğer kategoriye ait ürün varsa silme 
            var result = _productService.GetAllByCategory(categoryId);
            if (result.Data.Count > 0)
            {
                return new ErrorResult(Messages.CategoryIsNotEmpty);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryNameAlreadyExists(string categoryName)
        {
            var result = _categoryDal.GetAll(c=>c.CategoryName==categoryName);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExists);
            }
            return new SuccessResult();
        }

      
    }
}
