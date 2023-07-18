using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services.Interfaces
{
    public interface ICategoryAdminService
    {
        Task<bool> IsCategoryAdmin(long categoryId);
    }
}
