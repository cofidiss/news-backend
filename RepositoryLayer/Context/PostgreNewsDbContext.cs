using Microsoft.EntityFrameworkCore;
using RepositoryLayer.EntityConfigurations.PostgreNews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    public class PostgreNewsDbContext:DbContext
    {

    public PostgreNewsDbContext(DbContextOptions<PostgreNewsDbContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionsBuilder.EnableSensitiveDataLogging().LogTo(message => Debug.WriteLine(message));


    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.HasDefaultSchema("news_schema");
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new NewCommentMap());
        //modelBuilder.ApplyConfiguration(new DiscountScopeMap());
        //modelBuilder.ApplyConfiguration(new DiscountCategoryMap());
        //modelBuilder.ApplyConfiguration(new UsersMap());

        base.OnModelCreating(modelBuilder);
    }
    }
}
