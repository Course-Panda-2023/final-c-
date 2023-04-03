namespace Zoo.ZooUtils.CustomException
{
    internal class AnimalDoesNotRelatedToException : Exception
    {
        public AnimalDoesNotRelatedToException(string message) : base(message) { }
    }
}
