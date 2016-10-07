namespace CounterMetrics.Infrastructure
{
    public interface IHasher
    {
        string Hash(string source);
    }
}