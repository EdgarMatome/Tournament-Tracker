﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class PrizeModel
    {
        //<summary>
        //The Unique Identifier for the Prize Model
        //</summary
        public int PrizeId { get; set; }

        //<summary>
        //The numeric Identifier for the Place eg(1 place, 2 place ect...)
        //</summary
        public int PlaceNumber { get; set; }

        //<summary>
        //The Friendly name in words for the place number e.g(First place, first runner up etc...)
        //</summary
        public string PlaceName { get; set; }

        //<summary>
        //The fixed amount this place earns or zero if it is not used!!!
        //</summary
        public decimal PrizeAmount { get; set; }

        //<summary>
        //The Percentage of the overrall take (prize)
        //</summary
        public double PrizePercentage { get; set; }

        public PrizeModel()
        {

        }

        public PrizeModel( string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
