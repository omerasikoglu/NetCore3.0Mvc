using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore3._0Mvc.helper
{
    public class ConnectionHelper
    {
        //public static string connection = @"Server=(localdb)\MSSQLLocalDB;Database=MyGamesDb;Trusted_Connection=true";
        public static string connection= @"Server=tcp:omerserver1.database.windows.net,1433;Initial Catalog=dbmyGamesDb;Persist Security Info=False;User ID=server;Password=omer@home54;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
