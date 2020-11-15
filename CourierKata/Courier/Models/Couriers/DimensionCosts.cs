using Courier.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Courier.Models.Couriers
{
    public static class DimensionCosts
    {
        private const int SM_DIMENSION_COST = 3;
        private const int M_DIMENSION_COST = 8;
        private const int L_DIMENSION_COST = 15;
        private const int XL_DIMENSION_COST = 25;

        private static Dictionary<string, decimal> DIMENSION_TO_COST = new Dictionary<string, decimal>()
        {
            { Dimensions.SM_DIMENSION, SM_DIMENSION_COST },
            { Dimensions.M_DIMENSION, M_DIMENSION_COST },
            { Dimensions.L_DIMENSION, L_DIMENSION_COST },
            { Dimensions.XL_DIMENSION, XL_DIMENSION_COST }
        };

        public static decimal GetCostFromDimension(string dimension)
        {
            if (DIMENSION_TO_COST.Keys.Contains(dimension)) { return DIMENSION_TO_COST[dimension]; }

            throw new Exception("Invalid courier parcel dimension");
        }
    }
}
