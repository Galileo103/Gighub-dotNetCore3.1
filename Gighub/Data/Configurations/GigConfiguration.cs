using Gighub.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gighub.Data.Configurations
{
    public class GigConfiguration : IEntityTypeConfiguration<Gig>
    {
        public void Configure(EntityTypeBuilder<Gig> builder)
        {
            builder.HasKey(i => i.Id);


            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.ArtistId)
                .IsRequired();

            builder.Property(g => g.GenreId)
                .IsRequired();


            builder.HasOne(a => a.Artist)
                .WithOne(g => g.Gig)
                .HasForeignKey<Gig>(f => f.ArtistId);

            builder.HasOne(m => m.Genre)
                .WithMany(m => m.Gigs)
                .HasForeignKey(f => f.GenreId);

            builder.Property(v => v.Venue)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
