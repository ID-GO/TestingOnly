using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Persistence.EntityConfig
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonId);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnType("varchar(100)")
                   .HasMaxLength(100);

            builder.Property(p => p.Document)
                   .IsRequired()
                   .HasColumnType("varchar(14)")
                   .HasMaxLength(14);
        }
    }
}
