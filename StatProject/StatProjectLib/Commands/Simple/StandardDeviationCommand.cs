namespace StatProjectLib.Commands.Simple
{
    public class StandardDeviationCommand : VarianceCommand
    {
        public override double Compute(double[] data)
        {
            var variance = base.Compute(data);
            return Math.Sqrt(variance);
        }
    }
}