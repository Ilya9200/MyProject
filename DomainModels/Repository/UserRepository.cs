using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class UserRepository : IUserRepository
    {
        private string conString;

        public UserRepository(string conString)
        {
            this.conString = conString;
        }
    
        public void Insert(User user)
        {
            try
            {
                using (var connection = new SqlConnection(conString))
                {
                    SqlCommand command = new SqlCommand(@"Insert into User(Uid,Login,Password,FIO) values(+Guid.NewGuid()+" + user.Login + "," + user.Password + "," + user.FIO + ".)", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(User user)
        {
            try
            {
                using (var connection = new SqlConnection(conString))
                {

                    SqlCommand command = new SqlCommand("Delete from user where Uid=" + user.Uid + ";", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public User Get(int id)
        {
            try
            {
                using (var connection = new SqlConnection(conString))
                {

                    SqlCommand command = new SqlCommand("SELECT Id, FIO, Login FROM Users where Id = " + id + ";", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    User t = new User();
                    if (reader.HasRows)
                    {

                        reader.Read();
                        t.Id = reader.GetInt64(0);
                        t.FIO = reader.GetString(1);
                        t.Login = reader.GetString(2);
                        return t;
                    }
                    reader.Close();
                    return null;
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, FIO, Login FROM Users;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var fio = reader.GetString(1);
                        var login = reader.GetString(2);

                        yield return new User()
                        {
                            Id = id,
                            FIO = fio,
                            Login = login
                        };
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
            }
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}

