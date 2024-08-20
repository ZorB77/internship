namespace MovieApplicationWebAPI.Custom_Exceptions
{
    public class MovieNameIsNullException: Exception
    {
        public MovieNameIsNullException()
            : base("The name of the movie is null.")
        {
        }

        public MovieNameIsNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
