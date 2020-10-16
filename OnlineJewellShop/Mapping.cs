using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using OnlineJewellShop.Entity;
using OnlineJewellShop.Models;

namespace OnlineJewellShop
{
    public enum MemberRole
    {
        User,
        Admin
    }
      public class Mapping
    {
        public static void MappingUserDatabase()
        {
            Mapper.Initialize(config=>
            {
                config.CreateMap<UserEntityModel, User>().ForMember(dest => dest.Role, opt => opt.MapFrom(src=>MemberRole.User));
                config.CreateMap<ProductModel, Product>();
                config.CreateMap<LoginModel, User>();
                config.CreateMap<ProductCatogeryModel,ProductCatogeries>();
                config.CreateMap<PaymentModel, Payment>(); ;
            });
        }
    }
}