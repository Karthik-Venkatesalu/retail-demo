using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Order
{
    public static class Mapper
    {
        public static Domain.Entities.Order MapToDomain(this Dto.Model.Order order)
        {
            return new Domain.Entities.Order()
            {
                AddressID = order.AddressID,
                CreatedTime = order.CreatedTime,
                ID = order.ID,
                OrderStatus = (OrderStatus)order.OrderStatusID,
                UpdatedTime = order.UpdatedTime
            };
        }

        public static Dto.Model.Order MapToDto(this Domain.Entities.Order order)
        {
            return new Dto.Model.Order()
            {
                ID = order.ID,
                UpdatedTime = order.UpdatedTime,
                AddressID  = order.AddressID,
                CreatedTime = order.CreatedTime,
                OrderStatusID = (int)order.OrderStatus
            };
        }
    }
}
