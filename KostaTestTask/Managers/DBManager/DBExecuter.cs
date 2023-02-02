using KostaTestTask.Attributes;
using KostaTestTask.Interfaces;
using System.Data.SqlClient;

namespace KostaTestTask.Managers.DBManager
{
    public class DBExecuter : IDBExecuter
    {
        private SqlConnection _cnn;
        private readonly ILogger<DBExecuter> _logger;

        public DBExecuter(ILogger<DBExecuter> logger, SqlConnection cnn)
        {
            _logger = logger;
            _cnn = cnn;
            _cnn.Open();
        }


        public void ExecuteNonQuery(string sql,object[] parameters)
        {
            //SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, _cnn);
            if (parameters != null)
            {
                AddParameters(cmd, parameters);
            }
            cmd.ExecuteNonQuery();
        }

        public async Task<List<T>> Reader<T>(string sql, object[] parameters) where T : class, new()
        {
            List<T> dataList = new List<T>();
            SqlCommand cmd = new SqlCommand(sql, _cnn);
            if(parameters != null)
			{
                AddParameters(cmd, parameters);
            }
            System.Reflection.PropertyInfo[]? properties = typeof(T).GetProperties();
            Dictionary<System.Reflection.PropertyInfo, FieldNameAttribute> attributeDictionary =
                new Dictionary<System.Reflection.PropertyInfo, FieldNameAttribute>();
            foreach (System.Reflection.PropertyInfo property in properties)
            {
                var attribute = property.GetCustomAttributes(typeof(FieldNameAttribute), true).SingleOrDefault() as FieldNameAttribute;
                attributeDictionary.Add(property, attribute);
            }
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Row = new T();
                    foreach (System.Reflection.PropertyInfo property in properties)
                    {
                        var attribute = attributeDictionary[property];
                        if (attribute != null)
                        {
                            var value = reader[attribute.FieldName];
                            if (value.GetType() != typeof(DBNull)) 
                            {
                                property.SetValue(Row, value);
                            }
                        }
                    }
                    dataList.Add(Row);
                }
                return dataList;
            }
        }

        public SqlCommand AddParameters(SqlCommand cmd, object[] parameters)
        {
            int i = 1;
            foreach (var parameter in parameters)
            {
                cmd.Parameters.Add(new SqlParameter($"param{i}", parameter));
                i++;
            }
            return cmd;
        }
    }
}
