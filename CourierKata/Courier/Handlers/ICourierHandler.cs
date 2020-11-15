using Courier.Models;

namespace Courier.Handlers
{
    public interface ICourierHandler
    {
        CourierResponse Handle(CourierQuery query);
    }
}