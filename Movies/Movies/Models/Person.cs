using System;
using System.Xml.Linq;

public class Person
{
    public int personId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime birthdate { get; set; }
    public string email { get; set; }

    public Person() { }
    public Person(int personId, string firstName, string lastName, DateTime birthday, string email)
    {
        this.personId = personId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthdate = birthday;
        this.email = email;

    }

    public string ToString()
    {
        return $"id: {personId}; \t first name: {firstName} \t last name: {lastName} \t date of birth: {birthdate} \t email: {email}";
    }
}