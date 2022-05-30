using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DomeinController
    {
        #region Properties
        private Fitness _fitness;
        #endregion

        #region Ctor
        public DomeinController(IDeviceRepository deviceRepo)
        {
            _fitness = new Fitness(deviceRepo);
        }

        public DomeinController()
        {
        }
        #endregion


        #region Methods

        public void RegistreerDevice(string nummer, string type)
		{
			Device.RemoveDevice(nummer, type);
		}

		public List<List<string>> GeefDevices()
		{
			return _fitness.GeefDevices()
				.Select(auto => new List<string>() { auto.Type })
				.ToList();
		}

		public string GeefDevices(string type)
		{
			return _fitness.GeefDevices(type).ToString();
		}

		public void WijzigDevice(string nummer, string type)
		{
			Device.MaintenanceDevice(nummer, type);
		}

		public void VerwijderDevice(string nummer, string nummerplaat)
		{
			Device.RemoveDevice(nummer, nummerplaat);
		}
		#endregion
	}
}