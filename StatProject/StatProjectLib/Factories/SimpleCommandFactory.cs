using StatProjectLib.Commands.Simple;

namespace StatProjectLib.Factories
{
    public class SimpleCommandFactory : IFactory<ISimpleCommand>
    {
        public ISimpleCommand? Create(string function)
        {
            switch(function)
            {
                case "avg":
                    return new AverageCommand();
                case "var":
                    return new VarianceCommand();
                case "std":
                    return new StandardDeviationCommand();
                default:
                    return null;
            }
        }
    }
}