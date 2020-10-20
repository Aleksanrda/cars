using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Core.Entities
{
    public class Car : Entity
    {
        public string Name { get; set; }

        public double Volume { get; set; }

        public double Consumption { get; set; }

        public int Capacity { get; set; }

        public int Price { get; set; }
    }
}
