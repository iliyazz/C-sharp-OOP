using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double hieght;

        public double Length
        {
            get{return this.length;}
            private set
            {
                this.CheckValue(value, nameof(this.Length));
                this.length = value;
            } 
        }
        public double Width 
        {
            get { return this.width; }
            private set
            {
                this.CheckValue(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height 
        {
            get { return this.hieght; }
            set
            {
                this.CheckValue(value, nameof(this.Height));
                this.hieght = value;
            }
        }

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        private void CheckValue(double value, string dimenssion)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{dimenssion} cannot be zero or negative.");
            }
        }
        public double SurfaceArea()
        {
            return (this.Width * this.Height + this.Width * this.Length + this.Height * this.Length) * 2;
        }
        public double LateralSurfaceArea()
        {
            return (this.Length + this.Width) * 2 * this.Height;
        }
        public double Volume()
        {
            return this.Length * this.Height * this.Width;
        }
    }
}
