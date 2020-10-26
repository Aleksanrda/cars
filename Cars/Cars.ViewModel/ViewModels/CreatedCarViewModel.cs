using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cars.ViewModel.ViewModels
{
    public class CreatedCarViewModel : IValidatableObject
    {
        public string Name { get; set; }

        public double Volume { get; set; }

        public double Consumption { get; set; }

        public int Capacity { get; set; }

        public int Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
             var errors = new List<ValidationResult>();

             if (string.IsNullOrWhiteSpace(Name))
                 errors.Add(new ValidationResult("Name is not specified"));

             if (Volume < 720 || Volume > 12560)
                 errors.Add(new ValidationResult("Invalid volume"));

             if (Consumption < 300 || Consumption > 500)
                 errors.Add(new ValidationResult("Invalid consumption"));

             if (Capacity < 300 || Capacity > 900)
                 errors.Add(new ValidationResult("Invalid capacity"));

             if (Price < 100000 || Price > 1000000)
                 errors.Add(new ValidationResult("Invalid price"));

             return errors;
        }
    }
}
