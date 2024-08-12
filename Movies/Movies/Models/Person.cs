using System;
using System.Xml.Linq;

public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }

    public Person() { }
    public Person(int personId, string firstName, string lastName, DateTime birthday, string email)
    {
        this.PersonId = personId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Birthdate = birthday;
        this.Email = email;

    }

    public string ToString()
    {
        return $"id: {PersonId};, first name: {FirstName}, last name: {LastName}, date of birth: {Birthdate:dd-MM-yyyy}, email: {Email}";
    }
}