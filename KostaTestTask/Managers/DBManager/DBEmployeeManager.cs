using KostaTestTask.Interfaces;
using KostaTestTask.Models;

namespace KostaTestTask.Managers.DBManager
{
	public class DBEmployeeManager : IEmployeeManager
    {
        private readonly ILogger<DBEmployeeManager> _logger;
        private readonly IDBExecuter _dbExecuter;

        public DBEmployeeManager(ILogger<DBEmployeeManager> logger,
            IDBExecuter dbExecuter)
        {
            _logger = logger;
            _dbExecuter = dbExecuter;
        }

        public Task<List<EmployeeModel>> Get(Guid departmentId)
        {
            var sql = $@"SELECT ID,FirstName,SurName,Patronymic,DateOfBirth,DocSeries,DocNumber,Position,DepartmentID From Empoyee Where DepartmentID = @param1";
            _logger.LogInformation("Sql is create");
            object[] parameters = { departmentId };
            return _dbExecuter.Reader<EmployeeModel>(sql,parameters);
        }

        public void Create(EmployeeModel model)
        {
            object[] parameters = {model.DepartmentID, model.SurName, model.FirstName, model.Patronymic, model.DateOfBirth, model.DocSeries, model.DocNumber, model.Position};
            var sql = $@"INSERT INTO Empoyee (DepartmentID,SurName,FirstName,Patronymic,DateOfBirth,DocSeries,DocNumber,Position)
VALUES (@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8);";
            _dbExecuter.ExecuteNonQuery(sql,parameters);
        }

        public void Update(EmployeeModel model)
        {
            object[] parameters = {model.Id, model.DepartmentID, model.SurName, model.FirstName, model.Patronymic, model.DateOfBirth, model.DocSeries, model.DocNumber, model.Position };
            var sql = $@"UPDATE Empoyee
SET DepartmentID = @param2, SurName = @param3,FirstName = @param4,Patronymic = @param5,DateOfBirth = @param6,DocSeries = @param7,DocNumber = @param8,Position = @param9
WHERE Id = @param1";
            _dbExecuter.ExecuteNonQuery(sql, parameters);
        }

        public void Delete(EmployeeModel model)
		{
            object[] parameters = { model.Id };
            var sql = $@"DELETE FROM Empoyee Where Id = @param1";
            _dbExecuter.ExecuteNonQuery(sql, parameters);
        }

    }
}
