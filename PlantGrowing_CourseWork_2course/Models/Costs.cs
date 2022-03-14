namespace PlantGrowing_CourseWork_2course.Models
{
    public class Costs
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public decimal Amount { get; set; }

        public int CostElementId { get; set; }

        public int CropCultureId { get; set; }

        public CostElement? CostElement { get; set; }

        public CropCulture? CropCulture { get; set; }

    }
}

