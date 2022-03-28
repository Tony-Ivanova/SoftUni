namespace ClassBoxData
{
    using System;
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                ValidateSize(value, nameof(this.Length));
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                ValidateSize(value, nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                ValidateSize(value, nameof(this.Height));
                this.height = value;
            }
        }

        private void ValidateSize(double value, string parameter)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{parameter} cannot be zero or negative.");
            }
        }

        public double SurfaceArea()
        {
            return 2 * (length * width) + this.LateralArea();
        }

        public double LateralArea()
        {
            return 2 * (length * height + width * height);
        }

        public double Volume()
        {
            return width * height * length;
        }
    }
}
