using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSystem
{
    internal interface IAlive
    {
        int Food { get; }
        int HealthScore { get; set; }
        string Name { get; }

    }
}
