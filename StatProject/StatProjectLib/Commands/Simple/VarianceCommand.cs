namespace StatProjectLib.Commands.Simple
{
    public class VarianceCommand : ISimpleCommand
    {
        public virtual double Compute(double[] data)
        {
            var average = data.Average();
            return data.Average(x => Math.Pow(x - average, 2));
        }
    }
}