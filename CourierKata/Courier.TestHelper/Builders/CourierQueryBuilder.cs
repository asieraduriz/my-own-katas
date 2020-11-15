using Courier.Models;
using Courier.Models.Couriers;
using Courier.Models.Query;
using System.Collections.Generic;

namespace Courier.TestHelper.Builders
{
    public class CourierQueryBuilder
    {
        private CourierQuery courierQuery;

        public CourierQueryBuilder()
        {
            courierQuery = new CourierQuery
            {
                Parcels = new List<Parcel>()
            };
        }

        public static CourierQueryBuilder ACourierQuery()
        {
            return new CourierQueryBuilder();
        }

        public CourierQueryBuilder WithParcelsOfDimension(string[] dimensions)
        {
            foreach(string dimension in dimensions)
            {
                WithParcelOfDimension(dimension);
            }

            return this;
        }

        public CourierQueryBuilder WithParcelOfDimension(string dimension)
        {
            courierQuery.Parcels.Add(new Parcel { Dimension = dimension });

            return this;
        }

        public CourierQueryBuilder WithSmParcel()
        {
            courierQuery.Parcels.Add(new Parcel { Dimension = Dimensions.SM_DIMENSION });

            return this;
        }

        public CourierQueryBuilder WithMParcel()
        {
            courierQuery.Parcels.Add(new Parcel { Dimension = Dimensions.M_DIMENSION });

            return this;
        }

        public CourierQueryBuilder WithLParcel()
        {
            courierQuery.Parcels.Add(new Parcel { Dimension = Dimensions.L_DIMENSION });

            return this;
        }

        public CourierQueryBuilder WithXLParcel()
        {
            courierQuery.Parcels.Add(new Parcel { Dimension = Dimensions.XL_DIMENSION });

            return this;
        }

        public CourierQuery Build()
        {
            return courierQuery;
        }
    }
}
