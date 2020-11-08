using Gighub.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gighub.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(i => i.Id);


            builder.Property(n => n.Name)
                    .IsRequired()
                    .HasMaxLength(25);
        }
    }
}
