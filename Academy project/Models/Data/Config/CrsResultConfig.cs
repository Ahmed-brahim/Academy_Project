using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Day2_MVC_Task.Models.Data.Config
{
	public class CrsResultConfig : IEntityTypeConfiguration<CrsResult>
	{
		public void Configure(EntityTypeBuilder<CrsResult> builder)
		{
			builder.HasKey(x => new {x.Trainee_Id , x.Course_Id});

			builder.HasOne(x => x.Trainee)
				.WithMany(x => x.CrsResults)
				.HasForeignKey(x => x.Trainee_Id).OnDelete(DeleteBehavior.Cascade);
			
			builder.HasOne(x => x.Course)
				   .WithMany(x => x.CrsResults)
				   .HasForeignKey(x => x.Course_Id).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
