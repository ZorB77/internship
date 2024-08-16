
namespace Movies.Persistance
{
    internal interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetAll();
        Review GetById(int id);
    }
}