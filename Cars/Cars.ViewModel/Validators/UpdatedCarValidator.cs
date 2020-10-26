using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Cars.ViewModel.ViewModels;

namespace Cars.ViewModel.Validators
{
    public class UpdatedCarValidator : AbstractValidator<UpdatedCarViewModel>
    {
        public UpdatedCarValidator()
        {
            RuleFor(i => i.Id).NotEmpty();
            RuleFor(n => n.Name).NotNull();
            RuleFor(v => v.Volume).InclusiveBetween(720, 12560);
            RuleFor(c => c.Consumption).InclusiveBetween(300, 500);
            RuleFor(c => c.Capacity).InclusiveBetween(300, 900);
            RuleFor(p => p.Price).InclusiveBetween(100000, 1000000);
        }
    }
}
