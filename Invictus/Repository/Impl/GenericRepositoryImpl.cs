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

        protected String getTableName(Type eClz)
        {
            Table table = (Table)eClz.GetCustomAttribute(typeof(Table));
            String tableName = table.Name;
            if ("" == tableName) {
                tableName = eClz.Name;
            }
            return tableName;
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

            String tableName = "";
            SqlConnection connection = null;
            SqlCommand statement = null;
            tableName = getTableName(getEntityClass());
            E entity = (E)Activator.CreateInstance(getEntityClass());

            SqlDataReader dataReader = loadResultSetById(tableName, connection, statement, Queries.SELECT_BY_ID_QUERY, id);
            if (dataReader.Read())
            {
                entity = buildEntity(dataReader);
            }
            dataReader.Close();
            return entity;
        }

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

        private SqlDataReader loadResultSetById(String tableName, SqlConnection connection,
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

        public void create(E entity)
        {
            // TODO: implement me
            SqlConnection connection = null;
            SqlCommand statement = null;

            connection = connectionManager.getConnection();
            PropertyInfo[] props = getEntityClass().GetProperties(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            statement = buildInsertStatement(props, connection, entity);

            statement.ExecuteNonQuery();
        }

        public SqlCommand buildInsertStatement(PropertyInfo[] props, SqlConnection connection, E entity)
        {
            SqlCommand statement = buildParamInsertStatement(props, connection);

            List<Object> entityFieldObjects = getEntityFieldObjects(props, entity);

            for (int i = 0; i < entityFieldObjects.Count - 1; i++) {
                statement.Parameters.AddWithValue("@param" + i, entityFieldObjects[i]);
            }

            return statement;
        }

        private SqlCommand buildParamInsertStatement(PropertyInfo[] props, SqlConnection connection)
        {
            String tableName = getTableName(getEntityClass());
            String columnNames = "";
            String columnValues = "";

            foreach (PropertyInfo prop in props)
            {
                IEnumerable<Attribute> attributes = prop.GetCustomAttributes();
                int i = 0;
                foreach (Attribute attribute in attributes)
                {
                    if (attribute.GetType() == typeof(Id))
                    {
                        break;
                    }
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

        private List<Object> getEntityFieldObjects(PropertyInfo[] props, E entity)
        {
            List<Object> entityFieldObjects = new List<Object>();
            Object entityId = null;
            foreach (PropertyInfo prop in props) {
                Id id = (Id)prop.GetCustomAttribute(typeof(Id));
                Column column = (Column)prop.GetCustomAttribute(typeof(Column));
                if (id != null) {
                    entityId = prop.GetValue(entity);
                    continue;
                }
                Object entityObject = prop.GetValue(entity);
                
                entityFieldObjects.Add(entityObject);
            }
            entityFieldObjects.Add(entityId);
            return entityFieldObjects;
        }

        public void update(E entity)
        {
            throw new NotImplementedException();
        }
    }
}


