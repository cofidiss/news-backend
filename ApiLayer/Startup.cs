using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Context;
using RepositoryLayer.RepositoryPattern;
using RepositoryLayer.RepositoryPattern.Implemantations;
using RepositoryLayer.RepositoryPattern.Interfaces;
using ServicesLayer.Services.Implemantations;
using ServicesLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<INewsCommentService, NewsCommentService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsFileService, NewsFileService>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion
            #region  Repositories
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<INewsCommentRepository, NewsCommentRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<INewsFileRepository, NewsFileRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion

            services.AddSwaggerGen();
            services.AddControllers();
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(IBaseService).Assembly));

            services.AddHttpContextAccessor();
            services.AddDbContext<PostgreNewsDbContext>(item => item.UseNpgsql(Configuration.GetConnectionString("PostgreNews")));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => { options.ExpireTimeSpan = TimeSpan.FromMinutes(20); options.SlidingExpiration = true; options.AccessDeniedPath = "/asd";options.Events.OnRedirectToLogin =  x => { x.Response.StatusCode = 401;return Task.CompletedTask; };});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            app.Use(async (context, next) =>
            {

           
                var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
                if (configuration["appBaseUrl"] == null)
                {
           
                    string appBaseUrl = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.PathBase}";
                    configuration["appBaseUrl"] = appBaseUrl;

                }
         
                await next.Invoke();
           
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }
            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
