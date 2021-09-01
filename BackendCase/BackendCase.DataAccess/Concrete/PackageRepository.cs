using BackendCase.DataAccess.Abstract;
using BackendCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendCase.DataAccess.Concrete
{
	public class PackageRepository : IPackageRepository
	{

		public Package CreatePackage(Package package)
		{
			using (var BackendCaseDbContext = new BackendCaseDbContext())
			{
				package.ValuePerKilo = (float)package.Price / package.Weight;
				BackendCaseDbContext.Add(package);
				BackendCaseDbContext.SaveChanges();
				return package;

			}
		}

		public List<Package> GetOptimalShipment()
		{

			using (var BackendCaseDbContex = new BackendCaseDbContext())
			{
				return BackendCaseDbContex.Packages.ToList();
			}
		}
	}
}
