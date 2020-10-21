using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Core.Entities;
using Cars.ViewModel;

namespace Cars.API
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CarViewModel, Car>();
        }
    }
}
