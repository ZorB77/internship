using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWebAPI.Models
{
    public class DistributionTests
    {
        [Fact]
        public void ShouldCreateDistribution()
        {
            var movie = new Movie { ID = 1, Name = "Interstellar", Description = "Space travelling.", Genre = "Romance", ReleaseDate = new DateTime(2014, 8, 18) };
            var studio = new Studio { ID = 1, Location = "Cluj-Napoca", EstablishmentYear = 2010, Name = "Abc" };
            var distribution = new Distribution { ID = 1, Details = "Details.", DistributionDate = new DateTime(2015, 4, 16), Movie = movie, Studio = studio };

            Assert.NotNull(distribution);
            Assert.NotNull(distribution.Details);
            Assert.Equal("Cluj-Napoca", distribution.Studio.Location);
            Assert.Equal(new DateTime(2015, 4, 16), distribution.DistributionDate);
        }
    }
}
