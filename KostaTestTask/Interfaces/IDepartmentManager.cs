using KostaTestTask.Models;

namespace KostaTestTask.Interfaces
{
	public interface IDepartmentManager
	{
		Task<List<DepartmentModel>> Get();
	}
}