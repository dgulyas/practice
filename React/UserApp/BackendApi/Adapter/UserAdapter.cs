using BackendApi.DTOs;
using BackendApi.ORM;

namespace BackendApi.Adapter
{
    public static class UserAdapter{
        public static UserDTO OrmToDto(UserORM user){
            return new UserDTO{
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                MailingAddress = user.EmailAddress
            };
        }

        public static List<UserDTO> OrmsToDtos(List<UserORM> users){
            return users.Select(user => OrmToDto(user)).ToList();
        }

        public static UserORM DtoToOrm(UserDTO user){
            return new UserORM{
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                MailingAddress = user.EmailAddress
            };
        }

        public static List<UserORM> DtosToOrms(List<UserDTO> users){
            return users.Select(user => DtoToOrm(user)).ToList();
        }
    }
}