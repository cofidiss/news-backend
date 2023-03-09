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
    public class NewsMap : BaseMap<NewsEntity>, IEntityTypeConfiguration<NewsEntity>
    {


        public override void Configure(EntityTypeBuilder<NewsEntity> builder)
        {
            builder.ToTable("news");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CategoryId).HasColumnName("category_id");
            builder.Property(x => x.Header).HasColumnName("header");
            builder.Property(x => x.Text).HasColumnName("text");
            base.Configure(builder);
        }
    }
}
