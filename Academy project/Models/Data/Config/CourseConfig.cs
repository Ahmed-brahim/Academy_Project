using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Day2_MVC_Task.Models.Data.Config
{
	public class CourseConfig : IEntityTypeConfiguration<Course>
	{
		public void Configure(EntityTypeBuilder<Course> builder)
		{
			builder.HasKey(x=> x.Id);

			builder.HasOne(e=>e.Department)
				.WithMany(e=>e.Courses)
				.HasForeignKey(e=>e.Dept_id).IsRequired(false)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}
