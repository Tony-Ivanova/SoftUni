namespace GenericScale
{
    using System;
    public class EqualityScale<T>
        where T : IComparable<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public T GetHeavier()
        {
            var comparison = left.CompareTo(right);

            if (comparison > 0)
            {
                return left;
            }
            else if (comparison < 0)
            {
                return right;
            }

            return default(T);
        }
    }
}