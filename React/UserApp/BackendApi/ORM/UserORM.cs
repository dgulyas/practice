using Microsoft.EntityFrameworkCore;

namespace BackendApi.ORM
{
    public class UserORM
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MailingAddress { get; set; }
        public string? EmailAddress { get; set; }   
    }

    class UsersDb : DbContext
    {
        public UsersDb(DbContextOptions options) : base(options) { }
        public DbSet<UserORM> Users { get; set; } = null!;
    }
}