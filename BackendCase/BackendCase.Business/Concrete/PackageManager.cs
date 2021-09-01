using BackendCase.Business.Abstarct;
using BackendCase.DataAccess;
using BackendCase.DataAccess.Abstract;
using BackendCase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendCase.Business.Concrete
{
	public class PackageManager : IPackageService
	{
		private IPackageRepository _packageService;


		BackendCaseDbContext BackendCaseDbContex = new BackendCaseDbContext();

		public PackageManager(IPackageRepository packageRepository)
		{
			_packageService = packageRepository;
		}
		public Package CreatePackage(Package package)
		{
			if (package.Price > 0 && package.Weight > 0)
			{
				return _packageService.CreatePackage(package);
			}

			else
			{
				throw new Exception("Paket fiyatı ve ağırlığı sıfırdan büyük olmalı");
			}

		}

		public List<Package> GetOptimalShipment()
		{
			var list = _packageService.GetOptimalShipment();
			int capacity = 104;
			int weight = 0;
			int remainingCapacity = 104;
			List<Package> optimalList = new List<Package>();

			var temp = from Package in list
					   where Package.ShipmentStatus == 0
					   orderby Package.ValuePerKilo descending
					   select Package;

		
			foreach (var Package in temp)
			{

				int packetWeight = Package.Weight;

				if (weight < capacity && packetWeight < remainingCapacity)
				{
					weight = weight + Package.Weight;
					remainingCapacity = capacity - weight;
					optimalList.Add(Package);
				}
				else
				{
					continue;
				}

			}

			foreach (var item in optimalList)
			{
				item.ShipmentStatus = 1;
				BackendCaseDbContex.Update(item);
				BackendCaseDbContex.SaveChanges();
			}
			return optimalList;
		}




	}
}
