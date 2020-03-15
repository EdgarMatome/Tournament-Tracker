using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnecetion
    {

        private const string PrizesFiles = "PrizeModels.csv";
        //TODO -wire up the CreatePrize for Text Files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Load the TextFile
            //Convert The Text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFiles.FullFilePath().LoadFile().ConvertToPrizeModels();

            //Find The Max ID
            int currentId = 1;


            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.PrizeId).First().PrizeId + 1;
            }

            model.PrizeId = currentId;

            //Add New Record With New ID (Max + 1)
            prizes.Add(model);

            //Convertthe ptrozes To List<String
            //Save The List<String> to TextFile 

            prizes.SaveToPrizesFile(PrizesFiles);

            return model;
        }
    }
}
