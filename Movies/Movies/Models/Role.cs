using System;


public class Role
{
	public int RoleId { get; set; }
	public Movie Movie { get; set; }
	public Person Person { get; set; }
	public string Name { get; set; }

	public string Description { get; set; }
			

	public Role() { }
	public Role(int roleId, Movie movie, Person person, string name, string description)
	{
		this.RoleId = roleId;
		this.Movie = movie;
		this.Person = person;
		this.Name = name;
		this.Description = description;
	}

	public string ToString()
	{
		return $"role id: {RoleId}, movie: {Movie.Name}, person: {Person.FirstName} {Person.LastName}, role name: {Name}, description: {Description}";
	}

}
