using DomainLayer.Entity.Postgre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.EntityConfigurations.PostgreNews
{
    public class CategoryMap : BaseMap<CategoryEntity>, IEntityTypeConfiguration<CategoryEntity>
    {


        public override void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("category");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.ParentId).HasColumnName("parent_id");
            base.Configure(builder);
        }
    
    }
}
