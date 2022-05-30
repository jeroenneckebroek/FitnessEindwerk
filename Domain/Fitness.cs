using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;

namespace Domain
{
    public class Fitness
    {
		#region Properties
		private IDeviceRepository _deviceRepo;

		private List<string> modellen = new()
		{
			{ "loopband"},
			{ "fiets"},
		};
		#endregion

		#region Ctor
		public Fitness(IDeviceRepository deviceRepo)
		{
			_deviceRepo = deviceRepo;
		}
		#endregion

		#region Methods
		public void ControleerDeviceGegevens(string nummer, string type)
		{
			if (String.IsNullOrWhiteSpace(type))
			{
				throw new FitnessException("Toestel type is ongeldig.");
			}
		}

		public void RegistreerDevice(string type)
		{
			_deviceRepo.Insert(new Device(type));
		}

		public List<Device> GeefDevices()
		{
			return _deviceRepo.Get();
		}

		public Device GeefDevices(string type)
		{
			return _deviceRepo.Read(type);
		}

		public void WijzigDevice(string nummer, string type)
		{
			//ControleerDeviceGegevens(nummer, type);

			_deviceRepo.Update(new Device(type));
		}

		public void VerwijderDevice(string nummer, string type)
		{
			_deviceRepo.Delete(nummer, type);
		}
		#endregion

	}
}
