using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Persistence.EntityConfig
{
    public class PersonPhoneConfig : IEntityTypeConfiguration<PersonPhone>
    {
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {
            builder.HasKey(pp => pp.PersonPhoneId);

            builder.HasOne(pp => pp.Person)
                   .WithMany(p => p.PhoneNumbers)
                   .HasForeignKey(pp => pp.PersonId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
