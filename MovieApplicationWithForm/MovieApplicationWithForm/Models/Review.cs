using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Review
{
    public int reviewID { get; set; }
    public int rating { get; set; }
    public string comment { get; set; }
    public Movie movie { get; set; }

}


public class ReviewViewModel
{
    public int reviewID { get; set; }
    public int rating { get; set; }
    public string comment { get; set; }
    public string movieName { get; set; }
}
