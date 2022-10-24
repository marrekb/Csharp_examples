namespace StatProjectLib.Commands.Simple
{
    public class AverageCommand : ISimpleCommand
    {
        public double Compute(double[] data)
        {
            return data.Average();
        }
    }
}