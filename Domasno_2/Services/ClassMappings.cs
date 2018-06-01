using AutoMapper;
using Domasno_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domasno_2.Services
{
    public class ClassMappings : Profile
    {
        public ClassMappings()
        {
            CreateMap<Employee, Person>();
            CreateMap<Address, Address_ViewModel>();
            CreateMap<Address, Address_ViewModel>().ReverseMap();
            CreateMap<Customer, Customer_VM>();
            CreateMap<Customer, Customer_VM>().ReverseMap();
            //CreateMap<Address_ViewModel, Address>();


        }
    }
}
