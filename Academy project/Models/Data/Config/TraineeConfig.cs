using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Day2_MVC_Task.Models.Data.Config
{
	public class TraineeConfig : IEntityTypeConfiguration<Trainee>
	{
		public void Configure(EntityTypeBuilder<Trainee> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(e => e.Department)
				.WithMany(e => e.Trainees)
				.HasForeignKey(e => e.Dept_id).IsRequired(false)
				.OnDelete(DeleteBehavior.NoAction);

			/*builder.HasMany(e => e.Courses)
				.WithMany(e => e.Trainees)
				.UsingEntity<CrsResult>();*/
				
		}
	}
}
