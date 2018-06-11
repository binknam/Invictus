using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Invictus.Utils
{
    public class ConnectionManager
    {
        private static  ConnectionManager instance = new ConnectionManager();
        private static SqlConnection sqlConnection;

        public static ConnectionManager getInstance()
        {
            return instance;
        }

        private ConnectionManager() {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            String dataSource = "";
            String dataBase = "";
            FileStream fs = new FileStream("databaseConfig.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("datasource");
            dataSource = xmlnode[0].InnerText.Trim();
            xmlnode = xmldoc.GetElementsByTagName("database");
            dataBase = xmlnode[0].InnerText.Trim();
            String url = @"Data Source=" + dataSource + ";Initial Catalog=" + dataBase + ";Integrated Security=True";
            sqlConnection = new SqlConnection(url);
        }

        public SqlConnection getConnection()
        {
            sqlConnection.Open();
            return sqlConnection;
        }

        public static void close(IDbConnection connection)
        {
            if (connection == null)
            {
                return;
            }
            try
            {
                connection.Close();
            }
            catch (Exception ignore)
            {
            }
        }
    }
}
