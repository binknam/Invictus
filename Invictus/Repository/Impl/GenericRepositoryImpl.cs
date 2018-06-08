using Invictus.Attributes;
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

        public E findById(I id)
        {

            String tableName = "";
            SqlConnection connection = null;
            SqlCommand statement = null;
            tableName = getTableName(getEntityClass());
            E entity = default(E);

            SqlDataReader dataReader = loadDataReaderById(tableName, ref connection, statement, Queries.SELECT_BY_ID_QUERY, id);
            if (dataReader.Read())
            {
                entity = buildEntity(dataReader);
            }
            if (connection != null)
            {
                dataReader.Close();
                connection.Close();
            }
            return entity;
        }




        private SqlDataReader loadDataReaderById(String tableName, ref SqlConnection connection,
                                            SqlCommand statement, String queryStatement, I id)
        {
            connection = connectionManager.getConnection();
            String idColumn = "";
            PropertyInfo[] props = getEntityClass().GetProperties(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                Id idAnnotation = (Id)prop.GetCustomAttribute(typeof(Id));
                Column column = (Column)prop.GetCustomAttribute(typeof(Column));
                if (idAnnotation != null)
                {
                    idColumn = column.Name;
                    break;
                }
            }

            String command = String.Format(queryStatement, tableName, idColumn);
            statement = new SqlCommand(command, connection);
            statement.Parameters.AddWithValue("@param", id);
            SqlDataReader dataReader = statement.ExecuteReader();
            return dataReader;
        }

        public List<E> findAll()
        {
            String tableName = getTableName(getEntityClass());

            List<E> result = new List<E>();
            SqlConnection connection = null;
            SqlCommand statement = null;
            SqlDataReader dataReader = loadDataReader(tableName, ref connection, ref statement, Queries.SELECT_ALL_QUERY);
            while (dataReader.Read())
            {
                result.Add(buildEntity(dataReader));
            }
            if (connection != null)
            {
                connection.Close();
                dataReader.Close();

            }
            return result;
        }

        protected SqlDataReader loadDataReader(String tableName, ref SqlConnection connection,
                                    ref SqlCommand statement,
                                    String queryStatement)
        {
            connection = connectionManager.getConnection();
            statement = new SqlCommand(String.Format(queryStatement, tableName), connection);
            SqlDataReader dataReader = statement.ExecuteReader();
            return dataReader;
        }

        public void create(E entity)
        {
            // TODO: implement me
            SqlConnection connection = null;
            SqlCommand statement = null;

            connection = connectionManager.getConnection();
            PropertyInfo[] props = getEntityClass().GetProperties(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            statement = buildInsertStatement(props, ref connection, entity);

            statement.ExecuteNonQuery();
            if (connection != null)
            {
                connection.Close();
            }
        }

        public SqlCommand buildInsertStatement(PropertyInfo[] props, ref SqlConnection connection, E entity)
        {
            SqlCommand statement = buildParamInsertStatement(props, connection);

            List<Object> entityFieldObjects = getEntityFieldObjects(props, entity);

            for (int i = 0; i < entityFieldObjects.Count; i++)
            {
                statement.Parameters.AddWithValue("@param" + i, entityFieldObjects[i]);
            }

            return statement;
        }

        private SqlCommand buildParamInsertStatement(PropertyInfo[] props, SqlConnection connection)
        {
            String tableName = getTableName(getEntityClass());
            String columnNames = "";
            String columnValues = "";


            int i = 0;
            foreach (PropertyInfo prop in props)
            {
                IEnumerable<Attribute> attributes = prop.GetCustomAttributes();
                foreach (Attribute attribute in attributes)
                {
                    if (attribute.GetType() == typeof(Column))
                    {
                        Column column = (Column)attribute;
                        columnNames += column.Name + ",";
                        columnValues += "@param" + i + ",";
                        i++;
                    }
                }
            }

            columnNames = columnNames.Substring(0, columnNames.Length - 1);
            columnValues = columnValues.Substring(0, columnValues.Length - 1);
            return new SqlCommand(String.Format(Queries.INSERT_QUERY, tableName, columnNames, columnValues), connection);
        }

        public void update(E entity)
        {
            // TODO: implement me
            SqlConnection connection = null;
            SqlCommand statement = null;
            connection = connectionManager.getConnection();
            PropertyInfo[] props = getEntityClass().GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            statement = buildUpdateStatment(props, ref connection, entity);

            statement.ExecuteNonQuery();

            if (connection != null)
            {
                connection.Close();
            }
        }

        private SqlCommand buildUpdateStatment(PropertyInfo[] props, ref SqlConnection connection, E entity)
        {
            int idIndex = 0;
            SqlCommand statement = buildParamUpdateStatement(props, ref idIndex, connection);

            List<Object> entityFieldObjects = getEntityFieldObjects(props, entity);

            for (int i = 0; i < entityFieldObjects.Count(); i++)
            {
                statement.Parameters.AddWithValue("@param" + i, entityFieldObjects[i]);
            }
            return statement;
        }


        private SqlCommand buildParamUpdateStatement(PropertyInfo[] props, ref int idIndex, SqlConnection connection)
        {
            String tableName = getTableName(getEntityClass());
            String updateQueryParam = "";
            List<String> columnNames = new List<String>();

            for (int i = 0; i < props.Count(); i++)
            {
                IEnumerable<Attribute> attributes = props[i].GetCustomAttributes();
                foreach (Attribute attribute in attributes)
                {
                    if (attribute.GetType() == typeof(Column))
                    {
                        Column column = (Column)attribute;
                        columnNames.Add(column.Name);
                    }
                    if (attribute.GetType() == typeof(Id))
                    {
                        idIndex = i;
                    }
                }
            }

            for (int i = 0; i < columnNames.Count(); i++)
            {
                if (i != idIndex)
                {
                    updateQueryParam += columnNames[i] + "=@param" + i + ",";
                }
            }
            updateQueryParam = updateQueryParam.Substring(0, updateQueryParam.Count() - 1);
            updateQueryParam += " WHERE " + columnNames[idIndex] + "=@param" + idIndex;

            return new SqlCommand(String.Format(Queries.UPDATE_QUERY, tableName, updateQueryParam), connection);
        }

        public void delete(I id)
        {
            String tableName = getTableName(getEntityClass());

            SqlConnection connection = null;
            SqlCommand statement = null;
            deleteById(tableName, ref connection, statement, Queries.DELETE_BY_ID_QUERY, id);
            if (connection != null)
            {
                connection.Close();
            }
        }

        private void deleteById(String tableName, ref SqlConnection connection, SqlCommand statement,
                                        String queryStatement, I id)
        {
            connection = connectionManager.getConnection();
            String idColumn = "";
            PropertyInfo[] props = getEntityClass().GetProperties(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                Id idAnnotation = (Id)prop.GetCustomAttribute(typeof(Id));
                Column column = (Column)prop.GetCustomAttribute(typeof(Column));
                if (idAnnotation != null)
                {
                    idColumn = column.Name;
                    break;
                }
            }
            statement = new SqlCommand(String.Format(queryStatement, tableName, idColumn), connection);
            statement.Parameters.AddWithValue("@param", id);
            statement.ExecuteNonQuery();
        }


        protected String getTableName(Type eClz)
        {
            Table table = (Table)eClz.GetCustomAttribute(typeof(Table));
            String tableName = table.Name;
            if ("" == tableName)
            {
                tableName = eClz.Name;
            }
            return tableName;
        }


        protected abstract Type getEntityClass();

        protected E buildEntity(SqlDataReader dataReader)
        {
            E entity = (E)Activator.CreateInstance(getEntityClass());

            //TODO: populate entity fields via Annotations (@Table, @Column) and Reflections
            PropertyInfo[] props = getEntityClass().GetProperties(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            entity = loadEntityFromResultSet(dataReader, entity, props, null);
            return entity;
        }

        private E loadEntityFromResultSet(SqlDataReader dataReader, E entity, PropertyInfo[] props, Object mainTableObject)
        {
            foreach (PropertyInfo prop in props)
            {
                Column column = (Column)prop.GetCustomAttribute(typeof(Column));
                Object columnObject = null;
                columnObject = dataReader[column.Name];
                prop.SetValue(entity, columnObject);
            }
            return entity;
        }


        private List<Object> getEntityFieldObjects(PropertyInfo[] props, E entity)
        {
            List<Object> entityFieldObjects = new List<Object>();
            foreach (PropertyInfo prop in props)
            {
                Id id = (Id)prop.GetCustomAttribute(typeof(Id));
                Column column = (Column)prop.GetCustomAttribute(typeof(Column));
                Object entityObject = prop.GetValue(entity);
                entityFieldObjects.Add(entityObject);
            }
            return entityFieldObjects;
        }

        public bool isExisted(I id)
        {
            E entity = findById(id);
            return (entity != null);
        }
    }
}


