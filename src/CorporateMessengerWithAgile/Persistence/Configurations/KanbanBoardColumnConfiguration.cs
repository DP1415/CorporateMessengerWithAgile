using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Configurations
{
    public class KanbanBoardColumnConfiguration : AbstractEntityTypeConfiguration<KanbanBoardColumn>
    {
        public override void Configure()
        {
            PropertyTitle(kbc => kbc.Title);
            builder.Property(kbc => kbc.PositionOnBoard).IsRequired();

            builder.HasOne(kbc => kbc.Team)
                   .WithMany(t => t.KanbanBoardColumns)
                   .HasForeignKey(kbc => kbc.TeamId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
