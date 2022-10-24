namespace StatProjectLib.Factories
{
    public interface IFactory<T>
    {
        T? Create(string function);
    }
}