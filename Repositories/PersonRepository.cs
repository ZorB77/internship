using MovieWinForms;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly MovieDbContext _dbContext;
        public PersonRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public void Add(Person entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbContext.Remove(GetById(id));
            _dbContext.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return _dbContext.People.ToList();
        }

        public Person GetById(int id)
        {
            return _dbContext.People.Find(id);
        }

        public void Update(Person entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
