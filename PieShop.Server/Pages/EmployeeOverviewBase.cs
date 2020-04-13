using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using PieShop.Server.Service;

namespace PieShop.Server.Pages
{
    public class EmployeeOverviewBase : ComponentBase
    {
		[Parameter]
		public string EmployeeId { get; set; }

		[Inject]
		public IEmployeeDataService EmployeeDataService { get; set; }

		public Employee Employee { get; set; } = new Employee();

		protected override async Task OnInitializedAsync()
		{
			Employees = await EmployeeDataService.GetAllEmployees();
		}

		public IEnumerable<Employee> Employees { get; set; }

		private List<Country> Countries { get; set; }

		private List<JobCategory> JobCategories { get; set; }
	}
}
