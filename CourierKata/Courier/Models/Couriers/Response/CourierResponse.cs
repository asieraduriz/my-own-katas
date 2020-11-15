using Courier.Models.Couriers.Response;
using System.Collections.Generic;

namespace Courier.Models
{
    public class CourierResponse
    {
        public CourierResponse()
        {
            Parcels = new List<Parcel>();
        }

        public decimal TotalPrice { get; set; }

        public List<Parcel> Parcels { get; set; }

        public SpeedyShipping SpeedyShipping { get; set; }
    }
}
