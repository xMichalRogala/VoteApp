using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteApp.Backend.Core.Data.Seeds;

namespace VoteApp.Backend.Core.Data.Entities.Configurations
{
    public class VoterConfiguration : IEntityTypeConfiguration<Voter>
    {
        public void Configure(EntityTypeBuilder<Voter> builder)
        {
            builder.ToTable(nameof(VoteAppDbContext.Voters), Schemas.Core);

            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasOne(x => x.Vote)
                .WithOne(v => v.Voter)
                .HasForeignKey<Vote>(v => v.VoterId);

            builder.HasData(VoterSeed.Voters);
        }
    }
}
