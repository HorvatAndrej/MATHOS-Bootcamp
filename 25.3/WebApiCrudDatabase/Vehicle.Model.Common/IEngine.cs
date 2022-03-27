using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Model.Common
{
    public interface IEngine
    {
        int Id { get; set; }
        string Name { get; set; }
        string Type { get; set; }
       int ManufacturerId { get; set; }
    }
}
