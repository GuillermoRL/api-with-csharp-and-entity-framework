using Microsoft.EntityFrameworkCore;
using ProjectEntityFramework.Models;

namespace ProjectEntityFramework;

public class ActivitiesContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Activity> Activities { get; set; }

    public ActivitiesContext(DbContextOptions<ActivitiesContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5348"), Name = "Pendient Activities", Weight = 20 });
        categoriesInit.Add(new Category() { CategoryId = Guid.Parse("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5349"), Name = "Personal Activities", Weight = 50 });

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryId);

            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.Property(p => p.Weight);

            category.HasData(categoriesInit);
        });

        List<Activity> activitiesInit = new List<Activity>();
        activitiesInit.Add(new Activity() { ActivityId = Guid.Parse("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5350"), CategoryId = Guid.Parse("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5348"), Priority = Priority.medium, Title = "Payment of Services" });
        activitiesInit.Add(new Activity() { ActivityId = Guid.Parse("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5351"), CategoryId = Guid.Parse("2cf8aa8e-4a3c-479f-91c9-8a40bf1d5349"), Priority = Priority.low, Title = "Finishes Pendient Movies" });

        modelBuilder.Entity<Activity>(activity =>
        {
            activity.ToTable("Activity");
            activity.HasKey(p => p.ActivityId);

            activity.HasOne(p => p.Category).WithMany(p => p.Activities).HasForeignKey(p => p.CategoryId);
            activity.Property(p => p.Title).IsRequired().HasMaxLength(200);
            activity.Property(p => p.Description).IsRequired(false);
            activity.Property(p => p.Priority);
            activity.Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
            activity.Property(p => p.UpdatedAt).HasDefaultValue(DateTime.Now);
            activity.Ignore(p => p.Resume);

            activity.HasData(activitiesInit);
        });
    }
}