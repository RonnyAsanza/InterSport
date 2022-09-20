using System;

namespace InterSport.Domain.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public int BrandId { get; set; }
        public string DescriptionB { get; set; }
        public int CategoryId { get; set; }
        public string DescriptionC { get; set; }
        public int? ImageId { get; set; }
        public string ImagePath { get; set; }
        public string ImageName { get; set; }
        public string Base64 { get; set; }
        public string Extension { get; set; }
        public DateTime DateRegistration { get; set; }
    }
}
