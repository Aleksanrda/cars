using System;
using System.Collections.Generic;
using System.Text;
using Cars.ViewModel.Validators;

namespace Cars.ViewModel.ViewModels
{
    public class UpdatedCarViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double Volume { get; set; }

        public double Consumption { get; set; }

        public int Capacity { get; set; }

        public int Price { get; set; }
    }
}
