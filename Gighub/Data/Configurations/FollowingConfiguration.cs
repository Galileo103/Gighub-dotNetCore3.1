using Gighub.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gighub.Data.Configurations
{
    public class FollowingConfiguration : IEntityTypeConfiguration<Following>
    {
        public void Configure(EntityTypeBuilder<Following> builder)
        {
            builder.HasKey(i => new { i.FollowerId, i.FolloweeId });

            builder.HasOne(x => x.Followee)
                .WithMany(x => x.Followees)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Follower)
                .WithMany(x => x.Followers)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
