using AutoMapper;
using DomainLayer.Model.Category;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.DTO;
using ServicesLayer.DTO.Category;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Implemantations
{
    public class CategoryService:ICategoryService
    {

        ICategoryRepository _categoryRepository { get; }
        IMapper _mapper { get; }
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoriesForNavBarDto>> GetCategoriesForNavBar()
        {
          var categoryEntities = await _categoryRepository.FilterAsync(x=> true);
            IList<CategoriesForNavBarDto> categoriesForNavBarDtoList = new List<CategoriesForNavBarDto>();

        var parentCategories = categoryEntities.Where(x => x.ParentId == null);

            foreach (var parentCategory in parentCategories)
            {

                var categoriesForNavBarDtoParent = new CategoriesForNavBarDto() { Id = parentCategory.Id, Name = parentCategory.Name };


                IList<CategoriesForNavBarDto> categoriesForNavBarDtoChildrenList = new List<CategoriesForNavBarDto>();
                categoriesForNavBarDtoParent.Children = categoriesForNavBarDtoChildrenList;
                var children = categoryEntities.Where(x => x.ParentId == parentCategory.Id).ToList();
                foreach (var child in children)
                {
                    var categoriesForNavBarDtoChild = new CategoriesForNavBarDto() { Id = child.Id, Name = child.Name };
                    categoriesForNavBarDtoChildrenList.Add(categoriesForNavBarDtoChild);
 
                }

                categoriesForNavBarDtoList.Add(categoriesForNavBarDtoParent);
            }
            return categoriesForNavBarDtoList;
        }

        public async Task<IEnumerable<CategoryLovDto>> GetCategoryLov()
        {
            var categoryEntities = await _categoryRepository.FilterAsync(x => true);
            IList<CategoryLovDto> categoryLovDtoList = new List<CategoryLovDto>();

            var parentCategories = categoryEntities.Where(x => x.ParentId == null);

            foreach (var parentCategory in parentCategories)
            {

                var categoryLovParent = new CategoryLovDto() { Id = parentCategory.Id, Name = parentCategory.Name };


                IList<CategoryLovDto> categoryLovDtoChildrenList = new List<CategoryLovDto>();
                categoryLovParent.Children = categoryLovDtoChildrenList;
                var children = categoryEntities.Where(x => x.ParentId == parentCategory.Id).ToList();
                foreach (var child in children)
                {
                    var categoryLovChild = new CategoryLovDto() { Id = child.Id, Name = child.Name };
                    categoryLovDtoChildrenList.Add(categoryLovChild);

                }

                categoryLovDtoList.Add(categoryLovParent);
            }
            return categoryLovDtoList;
        }

         async Task<IEnumerable<CategoryListForCRUDDto>> ICategoryService.GetCategoryListForCRUD()
        {
          var CategoryListForCRUDModelList =   await   _categoryRepository.GetCategoryListForCRUD();
         var categoryListForCRUDDtoList =   _mapper.Map<IEnumerable<CategoryListForCRUDModel>, IEnumerable< CategoryListForCRUDDto> > (CategoryListForCRUDModelList);

            return categoryListForCRUDDtoList;
        }

        Task<IEnumerable<CategoriesForNavBarDto>> ICategoryService.GetCategoriesForNavBar()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CategoryLovDto>> ICategoryService.GetCategoryLov()
        {
            throw new NotImplementedException();
        }

        async Task<ResponseDto> ICategoryService.DeleteCategory(long id)
        {
            var responseDto = new ResponseDto() { HasError = false, Message = "Deleted Succedfully" };

         var categoryEntities =   await  _categoryRepository.FilterAsync(x => x.Id.Equals(id));
            if (categoryEntities.Count() == 0)
            {
                responseDto.HasError = true;
                responseDto.Message = "could not find category to delete";
                return responseDto;
            }
            
          
            await _categoryRepository.DeleteAsync(categoryEntities.First());
            return responseDto;

        }
    }
}
