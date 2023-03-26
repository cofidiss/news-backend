﻿using ServicesLayer.DTO.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoriesForNavBarDto>> GetCategoriesForNavBar();
    }
}