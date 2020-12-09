using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Application.Order.Interfaces
{
    public interface IRepository
    {
        Domain.Entities.Order GetOrder(int orderID);
        Domain.Entities.Order CreateOrder(Domain.Entities.Order order);
    }
}
