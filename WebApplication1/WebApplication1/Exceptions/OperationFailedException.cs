namespace WebApplication1.Exceptions
{
    public class OperationFailedException : Exception
    {
        public OperationFailedException() { }
        public OperationFailedException(string message) : base(message) { }
    }
}
