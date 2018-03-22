using AutoMapper;
using DemoApp.Data.Entities;
using DemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Data
{
    public class DemoAppProfile : Profile
    {
        public DemoAppProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();

            CreateMap<Product, ProductViewModel>()
                .ReverseMap();

            CreateMap<Message, MessageViewModel>()
                .ReverseMap();

        }
    }
}
