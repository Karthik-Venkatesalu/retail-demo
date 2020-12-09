using Application.Dto.Request;
using Application.Dto.Response.Model;

namespace Application.Order.Interfaces
{
    public interface IRequestHandler
    {
        BaseResponse CreateOrder(Request<Dto.Model.Order> order);
        Response<Dto.Model.Order> GetOrder(int orderID);
    }
}