using DataAccessLayer.Models;

namespace BusinessAccessLayer.DTO
{
    public class UserDTO
    {
        public User User { get; set; }

        public UserDTO(User user) { 
            User = user;
        }
    }
}
