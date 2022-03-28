namespace P05_GreedyTimes
{
    public class Items
    {
        public string Key { get; set; }

        public long Value { get; set; }

        public void IncreasingValue(long value)
        {
            Value += value;
        }
    }
}
