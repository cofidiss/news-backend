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
    public class NewCommentMap:BaseMap<NewsCommentEntity>,IEntityTypeConfiguration<NewsCommentEntity>
    {
       

        public override void Configure(EntityTypeBuilder<NewsCommentEntity> builder)
        { 
            builder.ToTable("news_comment");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.NewsId).HasColumnName("news_id");
            builder.Property(x => x.Comment).HasColumnName("comment");     
            base.Configure(builder);
        }
    }
}
