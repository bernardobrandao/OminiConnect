using System.ComponentModel.DataAnnotations;

namespace OminiConnect.DTOs
{
    public class UserDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string PreferredChannel { get; set; }
    }
}
