using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Persistence.EntityConfig
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.AuthorId);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
