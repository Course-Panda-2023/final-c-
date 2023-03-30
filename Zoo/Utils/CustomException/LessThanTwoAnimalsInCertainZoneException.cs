namespace Zoo.Utils.CustomException
{
    internal class LessThanTwoAnimalsInCertainZoneException : Exception
    {
        public LessThanTwoAnimalsInCertainZoneException(string message) : base(message) { }
    }
}
