using BackendCase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendCase.Business.Abstarct
{
	public interface IPackageService
	{
		Package CreatePackage(Package package);
		List<Package> GetOptimalShipment();
	}
}
