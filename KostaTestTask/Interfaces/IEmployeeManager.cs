using KostaTestTask.Models;

namespace KostaTestTask.Interfaces
{
	public interface IEmployeeManager
	{
        public Task<List<EmployeeModel>> Get(Guid departmentId);

        public void Create(EmployeeModel model);

        public void Update(EmployeeModel model);

        public void Delete(EmployeeModel model);
    }
}