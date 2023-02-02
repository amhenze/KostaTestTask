using KostaTestTask.Interfaces;
using KostaTestTask.Models;

namespace KostaTestTask.Managers.DBManager
{
	public class DBDepartmentManager : IDepartmentManager
	{
		private readonly ILogger<DBDepartmentManager> _logger;
		private readonly IDBExecuter _dbExecuter;

		public DBDepartmentManager(ILogger<DBDepartmentManager> logger,
			IDBExecuter dbExecuter)
		{
			_logger = logger;
			_dbExecuter = dbExecuter;
		}

		public Task<List<DepartmentModel>> Get()
		{
			var sql = "SELECT ID,Name,Code,ParentDepartmentID FROM Department";
			_logger.LogInformation("Sql is create");
			return _dbExecuter.Reader<DepartmentModel>(sql, null);
		}

		public void Create(Guid ID, string Name, string Code, Guid ParentDepartmentID)
		{
			object[] parameters = { ID, Name, Code, ParentDepartmentID };
			var sql = $@"INSERT INTO Department(ID,Name,Code,ParentDepartmentID) Values(@param1,@param2,@param3,@param4)";
			_logger.LogInformation("Sql is create");
			_dbExecuter.ExecuteNonQuery(sql,parameters);
		}
	}
}
