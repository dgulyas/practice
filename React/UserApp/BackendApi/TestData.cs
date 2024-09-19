using BackendApi.DTOs;

namespace BackendApi
{
    public static class TestData
    {

        public static List<UserDTO> CreateUsers()
        {
            var users = new List<UserDTO>
            {
                new UserDTO
                {
                    FirstName = "Stan",
                    LastName = "War",
                    EmailAddress = "aaaa@gmail.com",
                    MailingAddress = "123 Fake Street"
                },
                new UserDTO
                {
                    FirstName = "Bob",
                    LastName = "Peace",
                    EmailAddress = "bbcb@gmail.com",
                    MailingAddress = "123 Real Street"
                },
                new UserDTO
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