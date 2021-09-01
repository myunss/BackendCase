using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendCase.Business.Abstarct;
using BackendCase.Business.Concrete;
using BackendCase.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendCase.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class PackageController : ControllerBase
	{
		private IPackageService _packageService;
		public PackageController(IPackageService packageService)
		{
			_packageService = packageService;
		}

		[HttpPost]
		public IActionResult Post([FromBody] Package package)
		{

			if (ModelState.IsValid)
			{
				var createdPackage = _packageService.CreatePackage(package);
				return Created(package.ID.ToString(), createdPackage);
			}
			return BadRequest();
		}

		[HttpGet]
		public List<Package> GetShip()
		{
			return _packageService.GetOptimalShipment();
		}


	}
}