using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Shapes
    {
        public  List<IShape> shapesList;
        public Shapes()
        {
            shapesList = new List<IShape>();
        }
        public void AddShape(IShape shape) { shapesList.Add(shape); }
        public void RemoveShapeAt(int index) { shapesList.RemoveAt(index); }


    }
}
