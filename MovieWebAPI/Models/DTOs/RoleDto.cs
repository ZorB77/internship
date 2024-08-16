namespace MovieWebAPI.Models.DTOs
{
    public class RoleDto
    {
        public int RoleId { get; set; }
        public int Movie { get; set; }
        public int Person { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
