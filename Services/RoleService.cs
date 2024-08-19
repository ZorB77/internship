using MovieAppRESTAPI.Repositories;
using MovieWinForms.Models;

namespace MovieAppRESTAPI.Services
{
    public class RoleService
    {
        private readonly IRepository<Role> _repository;
        public RoleService(IRepository<Role> repository)
        {
            _repository = repository; 
        }

        public void AddRole(Role entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<Role> GetRoles()
        {
            return _repository.GetAll();
        }

        public Role GetRole(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateRole(Role entity)
        {
            var role = _repository.GetById(entity.Id);
            role.Name = entity.Name;
            _repository.Update(role);
        }

        public void DeleteRole(int id)
        {
            try
            {
                _repository.Delete(id);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
