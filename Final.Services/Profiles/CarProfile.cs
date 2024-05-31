using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Data.Entities;
using Final.Services.DTO;
using Final.Service.DTO;

namespace Final.Service.Profiles 
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
        }
    }
}