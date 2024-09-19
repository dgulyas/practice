namespace BackendApi.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MailingAddress { get; set; }
        public string? EmailAddress { get; set; }
    }
}