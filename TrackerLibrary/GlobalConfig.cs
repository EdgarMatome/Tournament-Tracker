using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
   public static class GlobalConfig
    {
        public static IDataConnecetion Connecetion { get; private set; } 

        public static void InitializeCoinnections(DatabaseType db)
        {

            //Connecetions = new List<IDataConnecetion>();
            if (db == DatabaseType.sql)
            {
                //TODO - Set up the sql connector properly
                SqlConnector sql = new SqlConnector();
                Connecetion = sql;
            }

            else if (db == DatabaseType.TextFile)
            {
                //TODO - Create Text/File Connection
                TextConnector text = new TextConnector();
                Connecetion = text;
            }

        }

        public static string cnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
