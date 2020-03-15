using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;


namespace TrackerLibrary.DataAccess
{
    public class SqlConnector : IDataConnecetion
    {
        //TODO - Make the createPrize method actually save to the database
        /// <summary>
        /// Saves new prize to Database
        /// </summary>
        /// <param name="model">The prize information</param>
        /// <returns>The prize information including the identifier (PrizeId)</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            //Running Stored procedures
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.cnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.PlaceNumber);
                p.Add("@PlaceName ", model.PlaceName);
                p.Add("@PrizeAmount", model.PrizeAmount);
                p.Add("@PrizePercentage", model.PrizePercentage);
                p.Add("@PrizeId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);


                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.PrizeId = p.Get<int>("@PrizeId");

                return model;
            }
        }
    }
}
