using System;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        private static Func<SqlDataReader, User> parse = 
            (reader) => new User()
                                {
                                    Id = reader.GetInt64(0),
                                    FIO = reader.GetString(1),
                                    Login = reader.GetString(2),
                                    Uid = reader.GetGuid(3),
                                    Password = reader.GetString(4)
                                };

        private static string fields = "Id, FIO, Login, Uid, Password";

        public UserRepository() :
            base(parse, 
                string.Format("SELECT {0} FROM Users;", fields), 
                string.Format("SELECT {0} FROM Users WHERE Id = {{0}};", fields))
        {

        }

        public bool Valid(string userName, string password)
        {
            return false;
        }
    }


}
