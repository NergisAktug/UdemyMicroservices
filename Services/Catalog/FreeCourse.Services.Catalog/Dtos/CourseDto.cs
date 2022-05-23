using System;

namespace FreeCourse.Services.Catalog.Dtos
{
    internal class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedTime { get; set; }
        public FeatureDto Feature { get; set; }//Feature ile Course table2ları bire-bir iliskili oldugunu bu sekilde belitiyoruz
        public string CategoryId { get; set; }
        public CategoryDto Category { get; set; }//Productları donerken kategoryleride donmek icin kullanılır
    }
}
