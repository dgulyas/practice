using BackendApi.DTOs;

namespace BackendApi
{
    public static class TestData
    {

        public static List<User> CreateUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    FirstName = "Stan",
                    LastName = "War",
                    EmailAddress = "aaaa@gmail.com",
                    MailingAddress = "123 Fake Street"
                },
                new User
                {
                    FirstName = "Bob",
                    LastName = "Peace",
                    EmailAddress = "bbcb@gmail.com",
                    MailingAddress = "123 Real Street"
                },
                new User
                {
                    FirstName = "Josh",
                    LastName = "Stasis",
                    EmailAddress = "cccc@gmail.com",
                    MailingAddress = "123 Sureal Street"
                }
            };

            return users;
        }
    }
}