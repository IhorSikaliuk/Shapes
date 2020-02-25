using System;

namespace Shapes
{
    abstract class Shape
    {
        public string ShapeName { get; protected set; }
        public int ShapeID { get; protected set; }
        
        public abstract double GetPerimeter();
        public abstract double GetArea();
    }
    class Circle : Shape
    {
        public double Radius { get; }
        public const double PI = Math.PI;

        public Circle()
        {
            ShapeName = "Circle";
            ShapeID = 1;
            Radius = 0;
        }
        public Circle(double r)
        {
            ShapeName = "Circle";
            ShapeID = 1;
            Radius = r;
        }
        public override double GetPerimeter()
        {
            return (2 * PI * Radius);
        }
        public override double GetArea()
        {
            return (PI * Math.Pow(Radius, 2));
        }
    }
    class Triangle : Shape
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }
        public double AngleAB { get; }
        public double AngleBC { get; }
        public double AngleAC { get; }

        public Triangle()
        {
            ShapeName = "Triangle";
            ShapeID = 2;
            SideA = SideB = SideC = 0;
            AngleAB = AngleBC = AngleAC = 0;
        }
        public Triangle(double sideA, double sideB, double sideC = 0, double angleAB = 0, double angleDegreeAB = 0)
        {
            ShapeName = "Triangle";
            ShapeID = 2;
            SideA = sideA;
            SideB = sideB;
            if (sideC == 0 && angleAB == 0 && angleDegreeAB == 0)
            {
                SideA = SideB = SideC = 0;
                AngleAB = AngleBC = AngleAC = 0;
                Console.WriteLine("Input error: The data is insufficient to describe the triangle.");
            }
            else if (sideA < 0 || sideB < 0 || sideC < 0 || angleDegreeAB < 0 || angleDegreeAB > 180)
            {
                SideA = SideB = SideC = 0;
                AngleAB = AngleBC = AngleAC = 0;
                Console.WriteLine("Input error: Wrong data.");
            }
            else if (sideC != 0)
            {
                SideC = sideC;
                AngleAB = findAngle(SideA, SideB, SideC);
                AngleBC = findAngle(SideB, SideC, SideA);
                AngleAC = findAngle(SideA, SideC, SideB);
            }
            else
            {
                if (angleAB == 0)
                    angleAB = (angleDegreeAB * 180) / Math.PI;
                AngleAB = angleAB;
                SideC = Math.Sqrt((SideA * SideA) + (SideB * SideB) - (2 * SideA * SideB * Math.Cos(AngleAB)));
                AngleBC = findAngle(SideB, SideC, SideA);
                AngleAC = findAngle(SideA, SideC, SideB);
            }
        }
        public override double GetPerimeter()
        {
            return (SideA + SideB + SideC);
        }
        public override double GetArea()
        {
            return ( (SideA * SideB * Math.Sin(AngleAB)) / 2 );
        }
        public static double findAngle(double a, double b, double c)   //функція знаходить значення кута між сторонами A і B за трьома сторонами
        {
            return Math.Acos( (a*a + b*b - c*c) / (2 * a * b) );
        }
    }
    class Rectangle : Shape
    {
        public double SideA { get; }
        public double SideB { get; }

        public Rectangle()
        {
            ShapeName = "Rectangle";
            ShapeID = 3;
            SideA = 0;
            SideB = 0;
        }
        public Rectangle(double a, double b)
        {
            ShapeName = "Rectangle";
            ShapeID = 3;
            SideA = a;
            SideB = b;
        }
        public override double GetPerimeter()
        {
            return (2 * (SideA + SideB));
        }
        public override double GetArea()
        {
            return (SideA * SideB);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(8.08);
            Triangle triangle = new Triangle(17.2, 17.94, 14);
            Rectangle rectangle = new Rectangle(9.86, 15.11);

            Console.WriteLine("Enter number of shape, tnat need to calculate area and perimeter:\n1. Circle\n2. Triangle\n3. Rectangle");
            int maxNumber = 3;
            int inputNumber = 0;
            while(true)
            {
                try
                {
                    inputNumber = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                if (0 < inputNumber && inputNumber < (maxNumber + 1))
                    break;
                else
                    Console.WriteLine("Wrong number");
            }
            switch (inputNumber)
            {
                case 1:
                    Console.WriteLine($"Perimetr of circle = {circle.GetPerimeter()}");
                    Console.WriteLine($"Area of circle = {circle.GetArea()}");
                    break;
                case 2:
                    Console.WriteLine($"Perimetr of Triangle = {triangle.GetPerimeter()}");
                    Console.WriteLine($"Area of Triangle = {triangle.GetArea()}");
                    break;
                case 3:
                    Console.WriteLine($"Perimetr of Rectangle = {rectangle.GetPerimeter()}");
                    Console.WriteLine($"Area of Rectangle = {rectangle.GetArea()}");
                    break;
            }
            Console.ReadKey();
        }
    }
}
