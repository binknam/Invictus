using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Invictus.Models;

namespace Invictus.Controls
{
    class MainControls
    {
        private static Boolean isCreated = false;
        protected static MainControls controls;
        private SqlConnection sqlConnection;

        private MainControls(String dataBaseLink)
        {
            sqlConnection = new SqlConnection(dataBaseLink);
        }

        public static MainControls GetControls(String dataBase, String dataSource)
        {
            String config = System.IO.File.ReadAllText(@"DatabaseConfig.txt");
            if (!isCreated && config == "")
            {
                String dataBaseLink = "Data Source=" + dataSource + ";Initial Catalog=" + dataBase + ";Integrated Security=True";

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"DatabaseConfig.txt");
                file.WriteLine(dataSource);
                file.WriteLine(dataBase);
                controls = new MainControls(dataBaseLink);
                isCreated = true;
                return controls;
            }
            return controls;
        }

        public static MainControls GetControls()
        {
            String config = System.IO.File.ReadAllText(@"DatabaseConfig.txt");
            if (!isCreated && config != "")
            {
                String[] lines = config.Split('\n');
                String dataSource = lines[0];
                String dataBase = lines[1];
                String dataBaseLink = "Data Source=" + dataSource + ";Initial Catalog=" + dataBase + ";Integrated Security=True";
                return new MainControls(dataBaseLink);
            }
            return controls;
        }

        public void doActions(String action, CreateParam param)
        {
            if (action == "CREATE")
            {
                CreateControls createControls = new CreateControls();
                createControls.CreateTable(param.tableName, param.columns, param.dataTypes, param.primaryKey, sqlConnection);
            }
        }
    }
}
// @