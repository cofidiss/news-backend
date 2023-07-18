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
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T :BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
           
            builder.Property(x => x.LastUpdateDate).HasColumnName("last_update_date");
            builder.Property(x => x.LastUpdatedBy).HasColumnName("last_updated_by");
            builder.Property(x => x.CreationDate).HasColumnName("creation_date");
            builder.Property(x => x.CreatedBy).HasColumnName("created_by");
        }
    }
}
