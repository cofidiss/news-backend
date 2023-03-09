using DomainLayer.Entity.Postgre;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.EntityConfigurations.PostgreNews
{
    public class NewsFileMap : BaseMap<NewsFileEntity>, IEntityTypeConfiguration<NewsFileEntity>
    {


        public override void Configure(EntityTypeBuilder<NewsFileEntity> builder)
        {
            builder.ToTable("news_file");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Type).HasColumnName("type");
            builder.Property(x => x.ByteArray).HasColumnName("byte_array");
            builder.Property(x => x.NewsId).HasColumnName("news_id");
            builder.Property(x => x.Name).HasColumnName("name");
            base.Configure(builder);
        }
    }
}
