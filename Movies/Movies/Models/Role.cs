using System;


public class Role
{
	public int roleId { get; set; }
	public Movie movie { get; set; }
	public Person person { get; set; }
	public string name { get; set; }

	public Role() { }
	public Role(int roleId, Movie movie, Person person, string name)
	{
		this.roleId = roleId;
		this.movie = movie;
		this.person = person;
		this.name = name;
	}

}
