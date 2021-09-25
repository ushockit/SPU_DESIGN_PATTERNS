using System;

namespace ConsoleApp1
{
    interface IExportManager
    {
        void ExportDot(Dot dot);
        void ExportCircle(Circle circle);
        void ExportRectangle(Rectangle rectangle);
    }

    class XMLExportVisitor : IExportManager
    {
        public void ExportCircle(Circle circle)
        {
            // TODO: Export to XML for the circle
            Console.WriteLine("XML Export the circle");
        }

        public void ExportDot(Dot dot)
        {
            // TODO: Export to XML for the dot
            Console.WriteLine("XML Export the dot");
        }

        public void ExportRectangle(Rectangle rectangle)
        {
            // TODO: Export to XML for the rectangle
            Console.WriteLine("XML Export the rectangle");
        }
    }

    class JSONExportVisitor : IExportManager
    {
        public void ExportCircle(Circle circle)
        {
            // TODO: Export to JSON for the circle
            Console.WriteLine("JSON Export the circle");
        }

        public void ExportDot(Dot dot)
        {
            // TODO: Export to JSON for the dot
            Console.WriteLine("JSON Export the dot");
        }

        public void ExportRectangle(Rectangle rectangle)
        {
            // TODO: Export to JSON for the rectangle
            Console.WriteLine("JSON Export the rectangle");
        }
    }

    abstract class BaseShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public abstract void Accept(IExportManager visitor);
    }

    class Dot : BaseShape
    {
        public override void Accept(IExportManager visitor)
        {
            visitor.ExportDot(this);
        }
    }
    class Circle : BaseShape
    {
        public double Radius { get; set; }
        public override void Accept(IExportManager visitor)
        {
            visitor.ExportCircle(this);
        }
    }
    class Rectangle : BaseShape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public override void Accept(IExportManager visitor)
        {
            visitor.ExportRectangle(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new BaseShape[]
            {
                new Dot { X = 10, Y = 20 },
                new Circle { X = 5, Y = 3, Radius = 7.5 },
                new Rectangle { X = 1, Y = 0, Height = 10, Width = 20 }
            };

            var xmlVisitor = new XMLExportVisitor();
            var jsonVisitor = new JSONExportVisitor();

            foreach (var shape in shapes)
            {
                shape.Accept(jsonVisitor);
            }




            Console.WriteLine("Hello World!");
        }
    }
}
