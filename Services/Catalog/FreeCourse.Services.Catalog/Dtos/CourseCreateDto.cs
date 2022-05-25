﻿using System;

namespace FreeCourse.Services.Catalog.Dtos
{
    public class CourseCreateDto
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public FeatureDto Feature { get; set; }//Feature ile Course table2ları bire-bir iliskili oldugunu bu sekilde belitiyoruz
        public string CategoryId { get; set; }
       
    }
}
