namespace MRK
{
    public class BoxedTuple<T1, T2>(T1? item1 = default, T2? item2 = default)
    {
        public T1? Item1 { get; set; } = item1;
        public T2? Item2 { get; set; } = item2;
    }
}
