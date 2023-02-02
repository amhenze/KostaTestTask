using KostaTestTask.Interfaces;
using KostaTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace KostaTestTask.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DepatrmentTreeViewController : Controller
	{
		private readonly IDepartmentManager _departmentManager;
		private ILogger<DepatrmentTreeViewController> _logger;

		public DepatrmentTreeViewController(IDepartmentManager departmentManager,
			ILogger<DepatrmentTreeViewController> logger)
		{
			_departmentManager = departmentManager;
			_logger = logger;
		}
		[HttpGet("~/GetAllDepartment")]
		public async Task<ViewResult> GetAllDepartment()
		{
			List<DepartmentModel> departmentsList = await _departmentManager.Get();

			int lineCount = 0;
			List<DepartmentModel> departmentsSorted = new List<DepartmentModel>();
			List<DepartmentModel> parentList = new List<DepartmentModel>();
			int added = 0;
			int gen = 0;
			while (departmentsList.Count() != 0)
			{
				foreach (DepartmentModel department in departmentsList)
				{
					if (department.ParentDepartmentID == null)
					{
						departmentsSorted.Add(department);
						parentList.Add(department);
						departmentsList.Remove(department);
						gen++;
						lineCount++;
						added = 0;
						break;
					}
					if (department.ParentDepartmentID == parentList.Last().ID)
					{
						department.Gen += gen;
						departmentsSorted.Add(department);
						parentList.Add(department);
						departmentsList.Remove(department);
						gen++;
						lineCount++;
						added = 0;
						break;
					}
				}
				added++;
				if (added > 2 && parentList.Count>1)
				{
					parentList.RemoveAt(parentList.Count - 1);
					gen--;
				}
			}
			return View(departmentsSorted);
		}
	}
}
