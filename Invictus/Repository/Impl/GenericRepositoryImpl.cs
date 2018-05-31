using Invictus.Atributes;
using Invictus.Constants;
using Invictus.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Repository.Impl
{
    abstract class GenericRepositoryImpl<E, I> : GenericRepository<E, I>
    {
        protected ConnectionManager connectionManager = ConnectionManager.getInstance();
        public void create(E entity)
        {
           
        }

        protected String getTableName(Type eClz)
        {
            Table table = (Table)eClz.GetCustomAttribute(typeof(Table));
            String tableName = table.Name;
            if ("" == tableName) {
                tableName = eClz.Name;
            }
            return tableName;
        }

        private E loadResultSetById(String tableName, SqlConnection connection,
                                        SqlCommand statement, DataSet resultSet,
                                        String queryStatement, I id) {
            connection = connectionManager.getConnection();
            statement = connection.CreateCommand();
            String idColumn = "";
            FieldInfo[] fields = getEntityClass().GetFields();
            foreach (FieldInfo field in fields) {
                Id idAnnotation = (Id) field.GetCustomAttribute(typeof(Id));
                Column column = (Column) field.GetCustomAttribute(typeof(Column));
                if (idAnnotation != null)
                {
                    idColumn = column.Name;
                    break;
                }
            }
            statement.CommandText = String.Format(queryStatement, tableName, idColumn);
            statement.Parameters.AddWithValue("@param", id);
            E result = (E)statement.ExecuteScalar();
            return result;
        }

        protected abstract Type getEntityClass();

        public void delete(I id)
        {
            throw new NotImplementedException();
        }

        public List<E> findAll()
        {
            throw new NotImplementedException();
        }

        public E findById(I id)
        {
            E result;
            String tableName = "";
            SqlConnection connection = null;
            SqlCommand statement = null;
            DataSet resultSet = null;
            tableName = getTableName(getEntityClass());
            result = (E)Activator.CreateInstance(getEntityClass());

            result = loadResultSetById(tableName, connection, statement, resultSet, Queries.SELECT_BY_ID_QUERY, id);
            return result;
        }

        public void update(E entity)
        {
            throw new NotImplementedException();
        }
    }
}


