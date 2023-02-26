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
         public class UserMap :BaseMap<UserEntity>, IEntityTypeConfiguration<UserEntity>
        {
            public override void Configure(EntityTypeBuilder<UserEntity> builder)
            {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.UserName).HasColumnName("user_name");
            builder.Property(x => x.Password).HasColumnName("password");
            builder.Property(x => x.BirthDate).HasColumnName("birth_date");
            builder.Property(x => x.Email).HasColumnName("email");
            base.Configure(builder); 
        }
        }
    }
