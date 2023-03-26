﻿using AutoMapper;

using RepositoryLayer.RepositoryPattern.Interfaces;
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
    }
}