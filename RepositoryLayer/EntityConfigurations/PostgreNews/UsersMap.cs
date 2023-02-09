using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Entity.Postgre;

namespace RepositoryLayer.EntityConfigurations.PostgreNews
{
         public class UsersMap : IEntityTypeConfiguration<UsersEntity>
        {
            public void Configure(EntityTypeBuilder<UsersEntity> builder)
            {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("firm_id");
            builder.Property(x => x.UserName).HasColumnName("user_name");
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.BirthDate).HasColumnName("birth_date");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.LastUpdateDate).HasColumnName("last_update_date");
            builder.Property(x => x.LastUpdatedBy).HasColumnName("last_updated_by");
            builder.Property(x => x.CreationDate).HasColumnName("creation_date");
            builder.Property(x => x.CreatedBy).HasColumnName("created_by");
        }
        }
    }
