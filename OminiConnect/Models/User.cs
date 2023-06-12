namespace OminiConnect.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PreferredChannel { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
