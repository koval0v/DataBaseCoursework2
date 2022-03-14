using Microsoft.EntityFrameworkCore;
namespace PlantGrowing_CourseWork_2course.Models

{
    public class PlantsContext : DbContext
    {
        public DbSet<CostElement> CostElements { get; set; }
        public DbSet<CropCulture> CropCultures { get; set; }
        public DbSet<Costs> Costs { get; set; }

        public PlantsContext(DbContextOptions<PlantsContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
