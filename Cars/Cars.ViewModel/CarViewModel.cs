using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModel
{
    public class CarViewModel
    {
        [Required]
        public string Name { get; set; }

        public double Volume { get; set; }

        public double Consumption { get; set; }

        public int Capacity { get; set; }

        public int Price { get; set; }
    }
}
