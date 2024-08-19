using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class RoleMapper
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Description { get; set; }
    }
}
