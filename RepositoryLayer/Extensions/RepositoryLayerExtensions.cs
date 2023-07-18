using DomainLayer.Model.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Extensions
{
 public   static class RepositoryLayerExtensions
    {

        public static long?  GetUserInfoFromContext(this HttpContext httpContext)
        {
           long? _userId = null;
            var claim = httpContext.User.Claims.Where(x => x.Type.Equals(nameof(LoginResultModel.Id)));
            if (claim.Count() != 0)
            {
                _userId = Convert.ToInt64(claim.First());


            }

            return _userId;
        }
    }
}
