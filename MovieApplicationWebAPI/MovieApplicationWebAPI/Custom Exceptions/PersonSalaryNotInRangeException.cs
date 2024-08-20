namespace MovieApplicationWebAPI.Custom_Exceptions
{
    public class PersonSalaryNotInRangeException: Exception
    {
        public PersonSalaryNotInRangeException()
        {
        }

        public PersonSalaryNotInRangeException(int salary)
            : base(String.Format("Invalid salary range: {0}", salary))
        {
        }

        public PersonSalaryNotInRangeException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
