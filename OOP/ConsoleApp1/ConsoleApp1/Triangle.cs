using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Triangle:IShape

    {
        public string Name { get; }
        public abstract float GetSurface();
        public abstract float GetCircumference();
        public abstract override string ToString();


    }
}
