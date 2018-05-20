using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Invictus.Controls
{
    class CreateControls
    {
        public void CreateTable(String tableName, String[] columns, String[] dataTypes, String primaryKey, SqlConnection con)
        {
            con.Open();
            String query = "create table "+tableName+"(";
            for (int i = 0; i < columns.Count(); i++)
            {
                query += columns[i] + " " + dataTypes[i];
                if (columns[i] == primaryKey)
                {
                    query += " primary key";
                }
                query += ",\n";
            }
            query += ")";
            var command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
        }
    }
}
