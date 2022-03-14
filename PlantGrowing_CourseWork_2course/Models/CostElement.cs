namespace PlantGrowing_CourseWork_2course.Models
{
    public class CostElement
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<Costs>? Costs { get; set; }
    }
}
