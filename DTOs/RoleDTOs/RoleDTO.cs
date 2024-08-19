namespace MovieAppRESTAPI.DTOs.RoleDTOs
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        public int PersonId { get; set; }
    }
}
