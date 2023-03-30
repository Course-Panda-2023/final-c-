namespace Zoo.Utils.CustomException
{
    internal class TwoOrMoreAnimalsFromTheSameTypeException : Exception
    {
        public TwoOrMoreAnimalsFromTheSameTypeException(string message) : base(message)
        {

        }
    }
}
