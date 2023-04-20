namespace Zoo.Util.CustomException
{
    internal class TwoOfTheSameTourException : Exception
    {
        public TwoOfTheSameTourException(string message) : base(message) { }
    }
}
