using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    public class EquilateralTriangle:Triangle
    {
        private float sideLenght;
        private string name;

        public float SideLenght
        { get { return sideLenght; } set { sideLenght = value; } }

        public string Name { get => name; set => name = value; }

        public EquilateralTriangle(float lenght, string type)
        {
            sideLenght = lenght;
            this.name = type;
        }

        public override float GetSurface()
        {
            return ((float)(Math.Pow(sideLenght, 2) * Math.Sqrt(3) / 4));
        }
        public override float GetCircumference()
        {
            return sideLenght*3; 
        }

        public override string ToString()
        {
            return $"This is a equilateral triangle with the side lenght of {sideLenght}";
        }
    }
}
