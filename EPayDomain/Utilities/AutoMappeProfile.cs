using AutoMapper;
using EPayDomain.Entities;
using EPayDomain.Model;
using System;
using System.Collections.Generic;
using System.Text;

  
namespace EPayDomain.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PaymentRequest, Payment>();
            CreateMap<PaymentResponse, PaymentTransaction>();
            
        }
    }
}