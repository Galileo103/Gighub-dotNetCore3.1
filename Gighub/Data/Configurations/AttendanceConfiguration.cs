using Gighub.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gighub.Data.Configurations
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(i => new { i.GigId, i.AttendeeId });


                builder.HasOne<Gig>(g => g.Gig)
                .WithMany()
                .HasForeignKey(g => g.GigId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
