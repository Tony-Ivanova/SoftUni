namespace Point_in_Rectangle.Forms
{ 

    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft { get; private set; }
        public Point BottomRight { get; private set; }


        public bool Contains(Point point)
        {
            bool isHorizontal = this.TopLeft.X <= point.X &&
                this.BottomRight.X >= point.X;

            bool isVertical = this.TopLeft.Y <= point.Y &&
                this.BottomRight.Y >= point.Y;

            bool isInRectangle = isHorizontal && isVertical;

            return isInRectangle;
        }
    }
}
