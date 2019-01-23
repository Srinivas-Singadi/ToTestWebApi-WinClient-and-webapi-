using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWebApi.Models
{
	public class EmployeeModel
	{

		///<summary>
		///Employee Id
		/// </summary>

		public int EmpId { get; set; }

		///employee first name
		///

		public string FirstName { get; set; }

		/// employee lastNmame
		/// 

		public string LastName { get; set; }


		///employee address
		///
		public string Address { get; set; }
	}
}