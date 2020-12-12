using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Application.Order.Interfaces
{
    public interface IRepository
    {
        void CancelOrder(int orderID);
        Domain.Entities.Order CreateOrder(Domain.Entities.Order order, List<Application.Dto.Model.OrderProduct> orderProducts);
    }
}
