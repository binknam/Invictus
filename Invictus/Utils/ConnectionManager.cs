using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Utils
{
    class ConnectionManager
    {
        private static  ConnectionManager instance = new ConnectionManager();
        private static SqlConnection sqlConnection;

        public static ConnectionManager getInstance()
        {
            return instance;
        }

        private String url;
        private String username;
        private String password;

        private ConnectionManager()
        {

        }

        /**
         * This method should only be called ONCE when starting up the application
         */
        public void initialize(String url, String username, String password)
        {
            this.url = url;
            this.username = username;
            this.password = password;
            sqlConnection = new SqlConnection(this.url);
        }

        public String getUrl()
        {
            return url;
        }

        public String getUsername()
        {
            return username;
        }

        public String getPassword()
        {
            return password;
        }

        public SqlConnection getConnection()
        {
            sqlConnection.Open();
            return sqlConnection;
        }
        
    }
}
