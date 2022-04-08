namespace PlantGrowing_CourseWork_2course.Models
{
    public class CropCulture
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Income { get; set; }

        public int IncomeYear { get; set; }

        public ICollection<Costs>? Costs { get; set; }
    }
}
