    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Constants
{
    class Queries
    {
        public static String SELECT_ALL_QUERY = "SELECT * FROM %s";
        public static String INSERT_QUERY = "INSERT INTO %s(%s) VALUES(%s)";
        public static String UPDATE_QUERY = "UPDATE %s SET %s";
        public static String SELECT_BY_ID_QUERY = "SELECT * FROM %s WHERE %s = @param";
        public static String DELETE_BY_ID_QUERY = "DELETE FROM %s WHERE ID = ?";

        public static String _BY_NAME = "NAME = ?";
        public static String _BY_PRICE_RANGE = "PRICE >= ? AND PRICE <=?";
        public static String _BY_CATEGORY = "CATEGORYID = ?";
    
    }
}
