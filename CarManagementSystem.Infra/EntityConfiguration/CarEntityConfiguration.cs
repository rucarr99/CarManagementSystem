using CarManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarManagementSystem.Infra.EntityConfiguration
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Brand)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.RegistrationNumber)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}