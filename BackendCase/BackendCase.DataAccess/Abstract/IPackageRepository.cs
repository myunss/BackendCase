using BackendCase.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendCase.DataAccess.Abstract
{
	public interface IPackageRepository
	{
		Package CreatePackage(Package package);

		List<Package> GetOptimalShipment();
	}
}
