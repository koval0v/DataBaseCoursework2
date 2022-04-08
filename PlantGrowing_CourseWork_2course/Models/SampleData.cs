namespace PlantGrowing_CourseWork_2course.Models
{
    public class SampleData
    {
        public static void Initialize(PlantsContext context)
        {
            context.Database.EnsureCreated();
            if (context.Costs.Any())
            {
                return;
            }

            var cropCultures = new CropCulture[]
            {
                new CropCulture{Name = "Цукровий буряк", Income = 760500, IncomeYear = 2021 },
                new CropCulture{Name = "Пшениця", Income = 920927, IncomeYear = 2021 },
                new CropCulture{Name = "Яра", Income = 859142, IncomeYear = 2020 },
                new CropCulture{Name = "Пшениця озима", Income = 948413, IncomeYear = 2019 },
                new CropCulture{Name = "Ріпак", Income = 100926, IncomeYear = 2018 },
                new CropCulture{Name = "Кукурудза", Income = 349211, IncomeYear = 2018 },
                new CropCulture{Name = "Сіно", Income = 365951, IncomeYear = 2019 },
                new CropCulture{Name = "Чорний пар", Income = 870284, IncomeYear = 2020 },
                new CropCulture{Name = "Жито", Income = 496622, IncomeYear = 2019 },
                new CropCulture{Name = "Просо", Income = 365967, IncomeYear = 2018 }
            };
            foreach (CropCulture p in cropCultures)
            {
                context.CropCultures.Add(p);
            }
            context.SaveChanges();

            var costElements = new CostElement[]
            {
                new CostElement{Name = "Зарплата робітників" },
                new CostElement{Name = "Амортизація обладнання" },
                new CostElement{Name = "Ремонт агротехніки" },
                new CostElement{Name = "Обслуговування агротехніки" },
                new CostElement{Name = "Ремонт цеху" },
                new CostElement{Name = "Обслуговування цеху" },
                new CostElement{Name = "Паливо" }
            };
            foreach (CostElement s in costElements)
            {
                context.CostElements.Add(s);
            }
            context.SaveChanges();

            var costs = new Costs[]
            {
                new Costs{Year = 2019, Amount = 46321, CropCultureId = 8, CostElementId = 6 },
                new Costs{Year = 2018, Amount = 35565, CropCultureId = 7, CostElementId = 5 },
                new Costs{Year = 2018, Amount = 36636, CropCultureId = 3, CostElementId = 3 },
                new Costs{Year = 2020, Amount = 33255, CropCultureId = 6, CostElementId = 1 },
                new Costs{Year = 2021, Amount = 3332, CropCultureId = 4, CostElementId = 4 }
            };
            foreach (Costs c in costs)
            {
                context.Costs.Add(c);
            }
            context.SaveChanges();
        }
    }
}
