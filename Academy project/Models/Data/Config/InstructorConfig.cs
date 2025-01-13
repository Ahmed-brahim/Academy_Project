using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Day2_MVC_Task.Models.Data.Config
{
	public class InstructorConfig : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder.HasKey(x => x.Id);

			builder.HasOne(e => e.Course)
				.WithMany(e => e.Instructors)
				.HasForeignKey(e => e.Crs_id)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasOne(e => e.Department)
				.WithMany(e => e.Instructors)
				.HasForeignKey(e=> e.Dept_id)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
