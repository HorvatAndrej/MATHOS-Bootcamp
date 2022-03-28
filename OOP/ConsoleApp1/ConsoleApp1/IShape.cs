using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IShape
    {
        string Name { get; }
        float GetSurface();
        float GetCircumference();

    }
}
