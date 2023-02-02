using KostaTestTask.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace KostaTestTask.Models
{
	public class DepartmentModel
	{
		[FieldNameAttribute("ID")]
		public Guid ID { get; set; }
		[FieldNameAttribute("ParentDepartmentID")]
		public Guid? ParentDepartmentID { get; set; }
		[FieldNameAttribute("Code")]
		public string Code { get; set; }
		[FieldNameAttribute("Name")]
		public string Name { get; set; }
		public int Gen { get; set; }
	}
}
