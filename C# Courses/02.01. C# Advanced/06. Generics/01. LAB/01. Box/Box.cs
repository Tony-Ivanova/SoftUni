namespace BoxOfT
{
    using System.Collections.Generic;
    public class Box<T>
    {
        private List<T> boxes;

        public Box()
        {
            this.boxes = new List<T>();
        }

        public int Count => boxes.Count;

        public void Add(T element)
        {
            this.boxes.Add(element);
        }

        public T Remove()
        {
            T element = this.boxes[boxes.Count - 1];
            this.boxes.RemoveAt(boxes.Count - 1);

            return element;
        }
    }
}
