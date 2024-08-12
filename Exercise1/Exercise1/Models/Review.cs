﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int Rating { get; set; }
        public string Comment {  get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
