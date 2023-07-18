using AutoMapper;
using Microsoft.AspNetCore.Http;
using RepositoryLayer.Extensions;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Implemantations
{
    public class CategoryAdminService: ICategoryAdminService
    {
        ICategoryAdminRepository _categoryAdminRepository { get; }
        IMapper _mapper { get; }
        IHttpContextAccessor _httpContextAccessor;
        public CategoryAdminService(ICategoryAdminRepository categoryAdminRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _categoryAdminRepository = categoryAdminRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> IsCategoryAdmin(long categoryId)
        {
         var userId =    _httpContextAccessor.HttpContext.GetUserInfoFromContext();
          var categoeyEntity =    await  _categoryAdminRepository.FilterAsync(x => x.CategoryId==categoryId && x.UserId== userId);
            if (categoeyEntity.Count() != 0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
