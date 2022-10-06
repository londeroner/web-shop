using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Core.Models.OrderAggregate;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class OrderItemURLResolver : IValueResolver<OrderItem, OrderItemDTO, string>
    {
        private readonly IConfiguration _config;
        public OrderItemURLResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ItemOrdered.PictureUrl))
                return _config["ApiUrl"] + source.ItemOrdered.PictureUrl;

            return null;
        }
    }
}