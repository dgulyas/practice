using BackendApi.DTOs;
using BackendApi.ORM;

namespace BackendApi.Adapter
{
    public static class UserAdapter{
        public static UserDTO OrmToDto(UserORM user){
            return new UserDTO{
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                MailingAddress = user.MailingAddress
            };
        }

        public static List<UserDTO> OrmsToDtos(List<UserORM> users){
            return users.Select(user => OrmToDto(user)).ToList();
        }

        public static UserORM DtoToOrm(UserDTO user){
            return new UserORM{
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                MailingAddress = user.MailingAddress
            };
        }

        public static List<UserORM> DtosToOrms(List<UserDTO> users){
            return users.Select(user => DtoToOrm(user)).ToList();
        }
    }
}