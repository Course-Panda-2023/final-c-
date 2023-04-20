namespace Zoo.Util.CustomException
{
    internal class LessThanTwoAnimalsInCertainZoneException : Exception
    {
        public LessThanTwoAnimalsInCertainZoneException(string message) : base(message) { }
    }
}
