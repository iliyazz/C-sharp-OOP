﻿namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get => height; private set => height = value; }
        public double Width { get => width; private set => width = value; }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }
        public override string Draw()
        {
            return base.Draw() + " Rectangle";
        }
    }
}
