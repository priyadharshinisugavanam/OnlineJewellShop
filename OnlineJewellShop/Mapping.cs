using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OnlineJewellShop.Entity;
using OnlineJewellShop.Models;

namespace OnlineJewellShop
{
      public class Mapping
    {
        public static void MappingUserDatabase()
        {
            Mapper.Initialize(config=>
            {
                config.CreateMap<UserEntityModel, UserDetails>().ForMember(dest => dest.Role, opt => opt.MapFrom(src=>"User"));
                config.CreateMap<ProductModel, Product>();
                config.CreateMap<LoginModel, UserDetails>();
            });
        }
    }
}