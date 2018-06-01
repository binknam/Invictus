    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Constants
{
    class Queries
    {
        public static String SELECT_ALL_QUERY = "SELECT * FROM {0}";
        public static String INSERT_QUERY = "INSERT INTO {0}({1}) VALUES({2})";
        public static String UPDATE_QUERY = "UPDATE {0} SET {1}";
        public static String SELECT_BY_ID_QUERY = "SELECT * FROM {0} WHERE {1} = @param";
        public static String DELETE_BY_ID_QUERY = "DELETE FROM {0} WHERE ID = @param";

        public static String _BY_NAME = "NAME = ?";
        public static String _BY_PRICE_RANGE = "PRICE >= ? AND PRICE <=?";
        public static String _BY_CATEGORY = "CATEGORYID = ?";
    
    }
}
