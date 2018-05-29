using Invictus.Atributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invictus.Repository.Impl
{
    abstract class GenericRepositoryImpl<E, I> : GenericRepository<E, I>
    {
        public void create(E entity)
        {
            E result;
            String tableName = "";
            SqlConnection connection = null;
            SqlCommand statement = null;
            DataSet resultSet = null;
            try
            {
                tableName = getTableName(getEntityClass());
                result = (E)Activator.CreateInstance(getEntityClass());

                resultSet = loadResultSetById(tableName, connection, statement, resultSet, Queries.SELECT_BY_ID_QUERY, id);
                if (resultSet.next())
                {
                    result = buildEntity(resultSet);
                }
            }
            catch (InstantiationException | IllegalAccessException | SQLException | ClassNotFoundException e) {
                throw new AppException("Cannot find entity in table: " + tableName, e);
            } finally
            {
                closeConnection(connection, statement, resultSet);
            }
            return result;
        }

        protected String getTableName(Type eClz)
        {
            Table table = (Table)eClz.GetCustomAttributes(typeof(Table), true)[0];
            String tableName = table.Name;
            if ("" == tableName) {
                tableName = eClz.Name;
            }
            return tableName;
        }
    
        private DataSet loadResultSetById(String tableName, SqlConnection connection,
                                        SqlCommand statement, DataSet resultSet,
                                        String queryStatement, I id) throws SQLException, ClassNotFoundException {
        connection = connectionManager.getConnection();
        String idColumn = "";
        Field[] fields = getEntityClass().getDeclaredFields();
        for (Field field: fields){
            Id idAnnotation = field.getDeclaredAnnotation(Id.class);
            Column column = field.getDeclaredAnnotation(Column.class);
            if (idAnnotation != null){
                idColumn = column.name();
                break;
            }
        }
        statement = connection.prepareStatement(String.format(queryStatement, tableName, idColumn));
        statement.setObject(1, id);
        resultSet = statement.executeQuery();
        return  resultSet;
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
            throw new NotImplementedException();
        }

        public void update(E entity)
        {
            throw new NotImplementedException();
        }
    }
}


