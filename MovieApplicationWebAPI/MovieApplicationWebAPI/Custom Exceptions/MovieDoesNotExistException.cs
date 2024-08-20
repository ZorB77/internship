namespace MovieApplicationWebAPI.Custom_Exceptions
{
    public class MovieDoesNotExistException: Exception
    {
        public MovieDoesNotExistException()
            : base("The name of the movie is null.")
        {
        }

        public MovieDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
