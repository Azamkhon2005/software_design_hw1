using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSystem
{
    internal interface IClinic
    {
        public bool IsHealthy(IAlive animal);
    }
    class Clinic: IClinic
    {
        public bool IsHealthy(IAlive animal)
        {
            if(animal.HealthScore > 5)
            {
                return true;
            }
            return false;
        }
    }
}
