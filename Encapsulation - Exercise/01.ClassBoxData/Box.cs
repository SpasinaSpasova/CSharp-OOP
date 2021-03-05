using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;


        public Box(double l, double w, double h)
        {
            this.Length = l;
            this.Width = w;
            this.Height = h;
        }
        public double Length
        {
            get => this.length;
            private set
            {
                Validation.ThrowIsInvalidSide(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                Validation.ThrowIsInvalidSide(value, nameof(this.Width));
                this.width = value;
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                Validation.ThrowIsInvalidSide(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            // 2lw + 2lh + 2wh
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double LateralSurfaceArea()
        {
            //2lh + 2wh
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {

            //lwh
            return this.Length * this.Width * this.Height;

        }
    }
}
