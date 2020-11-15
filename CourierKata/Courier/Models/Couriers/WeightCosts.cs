using System;
using System.Collections.Generic;
using System.Linq;

namespace Courier.Models.Couriers
{
    public class WeightCosts
    {
        private const int DOLLAR_TO_KILO_QUOTA = 2;

        private const int SM_WEIGHT = 1;
        private const int M_WEIGHT = 3;
        private const int L_WEIGHT = 6;
        private const int XL_WEIGHT = 10;
        private static Dictionary<string, decimal> WEIGHT_TO_COST = new Dictionary<string, decimal>()
        {
            { Dimensions.SM_DIMENSION, SM_WEIGHT },
            { Dimensions.M_DIMENSION, M_WEIGHT },
            { Dimensions.L_DIMENSION, L_WEIGHT },
            { Dimensions.XL_DIMENSION, XL_WEIGHT }
        };

        public static decimal GetCostFromDimension(string dimension)
        {
            if (WEIGHT_TO_COST.Keys.Contains(dimension))
            {
                return WEIGHT_TO_COST[dimension] * DOLLAR_TO_KILO_QUOTA;
            }

            throw new Exception("Invalid courier parcel dimension");
        }
    }
}
