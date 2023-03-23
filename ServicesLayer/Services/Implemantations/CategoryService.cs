using AutoMapper;
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
        public Task<IEnumerable<CategoriesForNavBarDto>> GetCategoriesForNavBar()
        {
            
        }
    }
}
