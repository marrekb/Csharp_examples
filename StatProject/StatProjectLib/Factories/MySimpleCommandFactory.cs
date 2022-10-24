using StatProjectLib.Commands.Simple;

namespace StatProjectLib.Factories
{
    public class MySimpleCommandFactory : IMyFactory<ISimpleCommand>
    {
        private readonly Dictionary<string, Func<ISimpleCommand>> _commands;

        public MySimpleCommandFactory()
        {
            _commands = new Dictionary<string, Func<ISimpleCommand>>();
        }

        public ISimpleCommand? Create(string function)
        {
            return _commands.TryGetValue(function, out var command) ? command() : null;
        }

        public void Register(string function, Func<ISimpleCommand> func)
        {
            _commands.Add(function, func);
        }

        public void Register<U>(string function) where U : ISimpleCommand, new()
        {
            _commands.Add(function, () => new U());
        }
    }
}
