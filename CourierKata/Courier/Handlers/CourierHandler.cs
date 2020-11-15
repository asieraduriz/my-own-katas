using Courier.Models;
using Courier.Models.Couriers;
using Courier.Models.Couriers.Response;

namespace Courier.Handlers
{
    public class CourierHandler : ICourierHandler
    {
        public CourierResponse Handle(CourierQuery query)
        {
            var courierResponse = new CourierResponse();

            decimal courierTotalPrice = 0;

            foreach(var parcel in query.Parcels)
            {
                decimal parcelCost = DimensionCosts.GetCostFromDimension(parcel.Dimension);
                decimal weightedCost = WeightCosts.GetCostFromDimension(parcel.Dimension);
                courierTotalPrice += parcelCost + weightedCost;
                courierResponse.Parcels.Add(new Parcel
                {
                    Cost = parcelCost + weightedCost
                });
            }

            courierResponse.TotalPrice = courierTotalPrice;
            courierResponse.SpeedyShipping = new SpeedyShipping { TotalPrice = courierTotalPrice * 2 };

            return courierResponse;
        }
    }
}
