using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int RoleId { get; set; }
	public Movie Movie { get; set; }
	public Person Person { get; set; }
	public string Name { get; set; }
	public string? Description { get; set; }
			

	public Role() { }

    public Role(int roleId, Movie movie, Person person, string name, string description)
    {
        RoleId = roleId;
        Movie = movie;
        Person = person;
        Name = name;
        Description = description;
    }

    public string ToString() => $"role id: {RoleId}, movie: {Movie.Name}, person: {Person.FirstName} {Person.LastName}, role name: {Name}, description: {Description}";

}
