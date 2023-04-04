namespace Zoo.Util.CustomException
{
    internal class TwoOrMoreAnimalsFromTheSameTypeException : Exception
    {
        public TwoOrMoreAnimalsFromTheSameTypeException(string message) : base(message)
        {

        }
    }
}
