using KostaTestTask.Interfaces;
using KostaTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace KostaTestTask.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : Controller
	{
		private readonly IEmployeeManager _employeeManager;
		private ILogger<EmployeeController> _logger;

		public EmployeeController(IEmployeeManager employeeManager, ILogger<EmployeeController> logger)
		{
			_employeeManager = employeeManager;
			_logger = logger;
		}

		[HttpGet("~/GetEmployees")]
		public async Task<ViewResult> GetEmployees(Guid departmentId)
		{
			List<EmployeeModel> employeeList = await _employeeManager.Get(departmentId);
			return View(employeeList);
		}

		[HttpGet("~/CreateEmployeesForm")]
		public ViewResult CreateEmployeesForm()
		{
			return View();
		}

		[HttpGet("~/AddEmployees")]
		public void AddEmployees(decimal Id,Guid DepartmentID,string SurName, string FirstName, string Patronymic, DateTime DateOfBirth, string DocSeries, string DocNumber, string Position)
		{
			EmployeeModel model = new EmployeeModel();
			model.Id = Id;
			model.DepartmentID = DepartmentID;
			model.SurName = SurName;
			model.FirstName = FirstName;
			model.Patronymic = Patronymic;
			model.DateOfBirth = DateOfBirth;
			model.DocSeries = DocSeries;
			model.DocNumber = DocNumber;
			model.Position = Position;
			_employeeManager.Create(model);
		}

		[HttpGet("~/EditEmployees")]
		public ViewResult EditEmployee(decimal Id, Guid DepartmentID, string SurName, string FirstName, string Patronymic, DateTime DateOfBirth, string DocSeries, string DocNumber, string Position)
		{
			EmployeeModel model = new EmployeeModel();
			model.Id = Id;
			model.DepartmentID = DepartmentID;
			model.SurName = SurName;
			model.FirstName = FirstName;
			model.Patronymic = Patronymic;
			model.DateOfBirth = DateOfBirth;
			model.DocSeries = DocSeries;
			model.DocNumber = DocNumber;
			model.Position = Position;
			return View(model);
		}

		[HttpGet("~/UpdateEmployee")]
		public void UpdateEmployee(decimal Id, Guid DepartmentID, string SurName, string FirstName, string Patronymic, DateTime DateOfBirth, string DocSeries, string DocNumber, string Position)
		{
			EmployeeModel model = new EmployeeModel();
			model.Id = Id;
			model.DepartmentID = DepartmentID;
			model.SurName = SurName;
			model.FirstName = FirstName;
			model.Patronymic = Patronymic;
			model.DateOfBirth = DateOfBirth;
			model.DocSeries = DocSeries;
			model.DocNumber = DocNumber;
			model.Position = Position;
			_employeeManager.Update(model);
		}

		[HttpGet("~/DeleteEmployee")] 
		public void DeleteEmployee(decimal id) // get для работы через ссылку
		{
			EmployeeModel model = new EmployeeModel();
			model.Id = id;
			_employeeManager.Delete(model);
		}
	}
}