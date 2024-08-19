namespace MovieWebAPI.Exceptions
{
    public class NullList : Exception
    {
        public NullList() { }

        public NullList(string errorMessage) : base(errorMessage) { }

        public NullList(string errorMessage, Exception innerException) : base(errorMessage, innerException) { }

    }
}
