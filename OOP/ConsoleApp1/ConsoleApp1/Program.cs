// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Square square=new Square(2,"square");
square.SideLenght = 3;
Console.WriteLine(square.GetCircumference());

ColouredSquare coloured= new ColouredSquare("green",5,"coloured square");
coloured.SideLenght = 4;
Console.WriteLine(coloured.GetCircumference());
Console.WriteLine(coloured.GetColour());

EquilateralTriangle equilateral = new EquilateralTriangle(3,"equilateral triangle");
Console.WriteLine(equilateral.GetSurface());
Console.WriteLine(equilateral.ToString());  

Shapes shapes=new Shapes();
shapes.AddShape(square);
shapes.AddShape(equilateral);









