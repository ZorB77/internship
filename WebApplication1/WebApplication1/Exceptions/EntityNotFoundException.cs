namespace WebApplication1.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }
        public EntityNotFoundException(string error) : base(error) { }
        public EntityNotFoundException(string merrorMessage, Exception innerException) : base(merrorMessage, innerException) { }

        public EntityNotFoundException(long entityId, string entityName) : base(FormattableString.Invariant($"'{entityName}' with the id '{entityId}' was not found")) { }
    }
}
