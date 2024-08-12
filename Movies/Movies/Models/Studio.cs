using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Studio
{
    public int StudioId { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string Location { get; set; }
    public Studio() { }
    public Studio(int StudioId, string Name, int Year, string Location)
    {
        this.StudioId = StudioId;
        this.Name = Name;
        this.Year = Year;
        this.Location = Location;

    }

    public string ToString()
    {
        return $"Id: {this.StudioId}, name: {this.Name}, year: {this.Year}, location: {this.Location};";
    }
}
