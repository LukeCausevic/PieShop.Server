using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PieShop.Server.Service;
using BethanysPieShopHRM.Shared;

namespace PieShop.Server.Pages
{
    public class EmployeeEditBase : ComponentBase
    {
		[Inject]
		public IEmployeeDataService EmployeeDataService { get; set; }

		[Inject]
		public ICountryDataService CountryDataService { get; set; }

		[Inject]
		public IJobCategoryDataService jobCategoryDataService { get; set; }

		[Parameter]
		public string EmployeeId { get; set; }

		protected string CountryId = string.Empty;

		protected string JobCategoryId = string.Empty;

		public Employee Employee { get; set; } = new Employee();

		public List<Country> Countries { get; set; } = new List<Country>();
		public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

		protected async override Task OnInitializedAsync()
		{
			Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
			Countries = (await CountryDataService.GetAllCountries()).ToList();
			JobCategories = (await jobCategoryDataService.GetAllJobCategories()).ToList();
			CountryId = Employee.CountryId.ToString();
			JobCategoryId = Employee.JobCategoryId.ToString();
		}
	}
}
