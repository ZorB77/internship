using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Person
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)] 
    public int PersonId { get; set; }
    [Required(ErrorMessage ="Firstname is required") ]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Lastname is required")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "The date of birth is required")]
    public DateTime Birthdate { get; set; }
    public string? Email { get; set; }

    public Person() { }
    public Person(int personId, string firstName, string lastName, DateTime birthday, string email)
    {
        this.PersonId = personId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Birthdate = birthday;
        this.Email = email;

    }

    public string ToString() => $"id: {PersonId};, first name: {FirstName}, last name: {LastName}, date of birth: {Birthdate:dd-MM-yyyy}, email: {Email}";
}