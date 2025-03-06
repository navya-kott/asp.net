using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class UserDto
    {
      
        public  string? Name { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }
    }
}
