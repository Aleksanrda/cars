using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Cars.Core.Entities;
using Cars.ViewModel;

namespace Cars.API.Infrastructure
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<CreatedCarViewModel, Car>();
            CreateMap<UpdatedCarViewModel, Car>();
        }
    }
}
