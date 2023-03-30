namespace Zoo.Utils.CustomException
{
    internal class DoctorAndFeederAnimalCollisionException : Exception
    {
        public DoctorAndFeederAnimalCollisionException(string message) : base(message) { }
    }
}
