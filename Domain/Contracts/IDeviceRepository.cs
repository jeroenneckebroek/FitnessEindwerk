using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IDeviceRepository
    {
        List<Device> Get();
        Device Read(string type);
        void Insert(Device device);
        void Delete(string nummer, string type);
        void Update(Device device);
    }
}
