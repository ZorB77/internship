using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using Moq;

public class StudioServiceTests
{
    private readonly StudioService _studioService;
    private readonly MyDBContext _myDBContext;

    public StudioServiceTests()
    {
        var options = new DbContextOptionsBuilder<MyDBContext>()
            .UseInMemoryDatabase(databaseName: "MovieApplicationTestDatabaseStudios")
            .Options;

        _myDBContext = new MyDBContext(options);
        _myDBContext.studios.RemoveRange(_myDBContext.studios);
        _myDBContext.SaveChanges();

        _myDBContext.studios.AddRange(
            new Studio { ID = 1, Name = "Warner Bros", EstablishmentYear = 1923, Location = "Burbank, California" },
            new Studio { ID = 2, Name = "Universal Pictures", EstablishmentYear = 1912, Location = "Universal City, California"}
            );
        _myDBContext.SaveChanges();

        _studioService = new StudioService(_myDBContext);
    }


    [Fact]
    public async Task ShouldGetAllStudios()
    {
        var studios = await _studioService.GetAllStudiosAsync();

        Assert.NotNull(studios);
        Assert.Equal(2, studios.ToList().Count());
    }

    [Fact]
    public async Task ShouldGetSpecificStudio()
    {
        var studio = await _studioService.GetStudioAsync(99999); 
        var studio2 = await _studioService.GetStudioAsync(1); 

        Assert.Null(studio);
        Assert.NotNull(studio2);
        Assert.Equal("Warner Bros", studio2.Name);
    }

    [Fact]
    public async Task ShouldAddStudio()
    {
        var newStudio = new Studio { ID = 3, Name = "Paramount Pictures", EstablishmentYear = 1912, Location = "Hollywood, California" };

        await _studioService.AddStudioAsync(newStudio);
        var studio = await _myDBContext.studios.FirstOrDefaultAsync(s => s.Name == "Paramount Pictures");

        Assert.NotNull(studio);
        Assert.Equal("Hollywood, California", studio.Location);
    }

    [Fact]
    public async Task ShouldUpdateStudio()
    {
        var studioToUpdate = new Studio { ID = 2, Name = "Universal Studios", EstablishmentYear = 1912, Location = "Universal City, California" };

        await _studioService.UpdateStudioAsync(2, studioToUpdate);
        var updatedStudio = await _studioService.GetStudioAsync(2);

        Assert.NotNull(updatedStudio);
        Assert.Equal("Universal Studios", updatedStudio.Name);
    }

    [Fact]
    public async Task ShouldDeleteStudio()
    {
        await _studioService.DeleteStudioAsync(2);
        var deletedStudio = await _myDBContext.studios.FirstOrDefaultAsync(s => s.ID == 2);

        Assert.Null(deletedStudio);
    }
}
