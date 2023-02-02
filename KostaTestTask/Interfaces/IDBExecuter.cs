using System.Data.SqlClient;

namespace KostaTestTask.Interfaces
{
	public interface IDBExecuter
	{
		void ExecuteNonQuery(string sql, object[] parameters);
		Task<List<T>> Reader<T>(string sql, object[] parameters) where T : class, new();
		SqlCommand AddParameters(SqlCommand cmd, object[] parameters);
	}
}