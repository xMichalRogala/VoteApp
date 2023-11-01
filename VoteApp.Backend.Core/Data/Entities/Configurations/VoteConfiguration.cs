using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VoteApp.Backend.Core.Data.Seeds;

namespace VoteApp.Backend.Core.Data.Entities.Configurations
{
    public class VoteConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable(nameof(VoteAppDbContext.Votes), Schemas.Core);

            builder.HasIndex(x => new { x.VoterId, x.CandidateId }).IsUnique();

            builder.HasData(VoteSeed.Votes);
        }
    }
}
