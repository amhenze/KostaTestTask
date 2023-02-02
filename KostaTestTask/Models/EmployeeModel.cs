using KostaTestTask.Attributes;
using MiNET.Utils;

namespace KostaTestTask.Models
{
	public class EmployeeModel
	{
		[FieldNameAttribute("ID")]
		public decimal Id { get; set; }
		[FieldNameAttribute("DepartmentID")]
		public Guid DepartmentID { get; set; }
		[FieldNameAttribute("SurName")]
		public string SurName { get; set; }
		[FieldNameAttribute("FirstName")]
		public string FirstName { get; set; }
		[FieldNameAttribute("Patronymic")]
		public string Patronymic { get; set; }
		[FieldNameAttribute("DateOfBirth")]
		public DateTime DateOfBirth { get; set; }
		[FieldNameAttribute("DocSeries")]
		public string DocSeries { get; set; }
		[FieldNameAttribute("DocNumber")]
		public string DocNumber { get; set; }
		[FieldNameAttribute("Position")]
		public string Position { get; set; }
	}
}
