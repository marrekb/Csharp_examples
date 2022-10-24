namespace StatProjectLib.Factories
{
    public interface IMyFactory<T>
    {
        T? Create(string function);
        void Register(string function, Func<T> func);
        void Register<U>(string function) where U : T, new();
    }
}