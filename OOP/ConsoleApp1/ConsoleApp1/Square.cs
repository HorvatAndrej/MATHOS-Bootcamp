using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Square : IShape
    {
        protected float sideLenght;
        private string name;

        public Square(float sideLenght, string name)
        {
            this.sideLenght = sideLenght;
            this.Name = name;
        }

        public float SideLenght
        { get { return sideLenght; } set { sideLenght = value; } }

        public string Name { get => name; set => name = value; }

        public float GetSurface()
        {
            return sideLenght * sideLenght;
        }
        public float GetCircumference()
        {
            return 4 * sideLenght;

        }


    }
}
