using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Studio
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int StudioId { get; set; }
    [Required(ErrorMessage = "The name of the studio is required")]
    public string Name { get; set; }
    [Range(0, 2100, ErrorMessage ="The year is not valid")]
    public int Year { get; set; }
    public string? Location { get; set; }
    public Studio() { }
    public Studio(int StudioId, string Name, int Year, string Location)
    {
        this.StudioId = StudioId;
        this.Name = Name;
        this.Year = Year;
        this.Location = Location;

    }

    public string ToString() => $"Id: {this.StudioId}, name: {this.Name}, year: {this.Year}, location: {this.Location};";
}
