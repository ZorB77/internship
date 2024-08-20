using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWebAPI.Models
{
    public class StudioTests
    {
        [Fact]
        public void ShouldCreateStudio()
        {
            var studio = new Studio { ID = 1, Location = "Cluj-Napoca", EstablishmentYear = 2010, Name = "Abc"};
            Assert.NotNull(studio);
            Assert.IsType<Studio>(studio);
            Assert.True(studio.ID == 1);
            Assert.Equal("Cluj-Napoca", studio.Location);
        }
    }
}
