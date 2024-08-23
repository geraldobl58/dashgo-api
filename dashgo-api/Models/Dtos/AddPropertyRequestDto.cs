using System.ComponentModel.DataAnnotations;

namespace dashgo_api.Models.Dtos
{
    public class AddPropertyRequestDto
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public int Bathroom { get; set; }
        public int Bedroom { get; set; }
        public int Garage { get; set; }
    }
}
