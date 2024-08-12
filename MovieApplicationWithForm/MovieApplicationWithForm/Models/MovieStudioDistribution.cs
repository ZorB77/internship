using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class MovieStudioDistribution
    {

        [Key] public int distributionID { get; set; }
        public Movie movie { get; set; }
        public Studio studio { get; set; }
        public DateTime distributionDate { get; set; }
        public string details { get; set; }
    }

