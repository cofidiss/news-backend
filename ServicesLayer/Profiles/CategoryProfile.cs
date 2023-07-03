using AutoMapper;
using DomainLayer.Model.Category;
using ServicesLayer.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Profiles
{
    internal class CategoryProfile : Profile
    {

        public CategoryProfile()
        {
            CreateMap< CategoryListForCRUDModel,CategoryListForCRUDDto > ();

            CreateMap<UpdateCategoryModel, UpdateCategoryDto>();
            
        }
    }
}
