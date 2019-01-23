
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
	public class EmployeeController : ApiController
	{
		public string FirstName { get; private set; }

		//// GET: Employee get

		[HttpGet]
		public List<EmployeeModel> Get()
		{
			List<EmployeeModel> emplist = null;
			try
			{
				TestWebApiEntities cntx = new TestWebApiEntities();
				var employees = cntx.Employees.ToList();
				emplist = new List<EmployeeModel>();
				foreach (var item in employees)
				{
					emplist.Add(new EmployeeModel()
					{
						EmpId = item.EmpId,
						FirstName = item.FirstName,
						LastName = item.LastName,
						Address = item.Address
					});
				}

				return emplist;
			}

			catch (Exception Ex)
			{
				return null;
			}
			// manoj


		}

		/// <summary>
		/// Post method
		/// </summary>

		[HttpPost]
		public EmployeeModel Post(EmployeeModel Model)
		{
			try
			{
				TestWebApiEntities cntx = new TestWebApiEntities();
                var employee = cntx.Employees.FirstOrDefault(); 
				if (employee != null)
				{
					employee.FirstName = Model.FirstName;
					employee.LastName = Model.LastName;
					employee.Address = Model.Address;


				}
				else
				{

					cntx.Employees.Add(new Employee() { EmpId = Model.EmpId, FirstName = Model.FirstName, LastName = Model.LastName, Address = Model.Address });
				}
				cntx.SaveChanges();
				return Model;
			}

			catch (Exception Ex)
			{
				return null;
			}
		}

	}
}
