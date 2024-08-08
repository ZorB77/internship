//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Movies.Persistance
//{
//    internal class RoleRepository : IRepository<Role>
//    {
//        protected readonly DbContext _context;
//        public RoleRepository(DbContext context)
//        {
//            _context = context;
//        }
//        public void Add(Role entity)
//        {
//            _context.Set<Role>().Add(entity);
//            _context.SaveChanges();
//        }

//        //public IEnumerable<Role> GetAll()
//        //{
//        //    return _context.Set<Role>().Include(e => e.Movie).Include(e => e.Person);
//        //}

//        public Role GetById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(Role entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Role entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
