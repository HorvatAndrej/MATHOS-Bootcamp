using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ColouredSquare:Square
    {
        private string colour;
        
        public ColouredSquare(string Colour, float sideLenght, string name) : base(sideLenght,name)
        {
            this.colour = Colour;
            
        }
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        

        public string GetColour()
        { return colour; }


    }
}
