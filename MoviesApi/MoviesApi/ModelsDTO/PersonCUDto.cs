using System.ComponentModel.DataAnnotations;

namespace MoviesApi.ModelsDTO
{
    public class PersonCUDto
    {

        public PersonCUDto(string firstName, string lastName, DateTime birthday, string nat, int award)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            Nationality = nat;
            Awards = award;
        }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime Birthday { get; set; }

        [StringLength(100)]
        public string Nationality { get; set; }
        public int Awards { get; set; }
    }
}
