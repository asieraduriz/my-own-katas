using Courier.Handlers;
using Courier.Models;
using Courier.Models.Couriers;
using Courier.TestHelper.Builders;
using System;
using System.Linq;
using Xunit;

namespace Courier.UnitTests.Handlers
{
    public class CourierHandlerShould
    {
        private CourierQuery courierQuery;
        private CourierHandler courierHandler;

        public CourierHandlerShould()
        {
            courierHandler = new CourierHandler();
        }

        [Theory]
        [InlineData(Dimensions.SM_DIMENSION, 5)]
        [InlineData(Dimensions.M_DIMENSION, 14)]
        [InlineData(Dimensions.L_DIMENSION, 27)]
        [InlineData(Dimensions.XL_DIMENSION, 45)]
        public void return_right_amount_of_cost_for_a_single_parcel_dimension(
            string parcelDimension, 
            decimal expectedCost)
        {
            courierQuery =
                CourierQueryBuilder.ACourierQuery()
                .WithParcelOfDimension(parcelDimension)
                .Build();

            var courierResponse = courierHandler.Handle(courierQuery);

            var parcelResponse = courierResponse.Parcels.First();
            Assert.Equal(expectedCost, parcelResponse.Cost);
        }

        [Fact]
        public void throw_missconfigured_parcel_when_dimension_is_not_standardized()
        {
            courierQuery = 
                CourierQueryBuilder.ACourierQuery()
                .WithParcelOfDimension("T")
                .Build();

            Assert.Throws<Exception>(() => courierHandler.Handle(courierQuery));
        }

        [Fact]
        public void return_speedy_shipping_to_be_double_the_total_price()
        {
            courierQuery =
                CourierQueryBuilder.ACourierQuery()
                .WithSmParcel()
                .WithMParcel()
                .Build();

            var courierResponse = courierHandler.Handle(courierQuery);
            Assert.Equal(courierResponse.TotalPrice * 2, courierResponse.SpeedyShipping.TotalPrice);
        }

        [Fact]
        public void add_weight_quota_to_L_parcel()
        {
            courierQuery =
                CourierQueryBuilder.ACourierQuery()
                .WithLParcel()
                .Build();

            var courierResponse = courierHandler.Handle(courierQuery);

            Assert.Equal(27, courierResponse.TotalPrice);
            Assert.Equal(27, courierResponse.Parcels[0].Cost);
        }
    }
}
