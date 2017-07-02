using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    class UserFavoriteResultRepository : IUserFavoriteResultRepository
    {
        private string conString;

        public UserFavoriteResultRepository(string conString)
        {
            this.conString = conString;
        }

        public IEnumerable<UserFavoriteResult> GetAll()
        {
            using (var connection = new SqlConnection(conString))
            {

                SqlCommand command = new SqlCommand(@"SELECT UserFavoriteResult.Id, Users.FIO, OperationResult.InputData, Operation.FullName, OperationResult.Result FROM
UserFavoriteResult INNER JOIN OperationResult ON UserFavoriteResult.Result = OperationResult.Id INNER JOIN 
Operation ON OperationResult.Operation = Operation.Id INNER JOIN Users ON Users.Id = OperationResult.Author; ", connection);
                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var Id = reader.GetInt64(0);

                        User user = new User();
                        user.FIO = reader.GetString(1);

                        Operation oper = new Operation();
                        oper.FullName = reader.GetString(3);

                        OperationResult operRes = new OperationResult();
                        operRes.InputData = reader.GetString(2);
                        operRes.Result = reader.GetDouble(4);
                        operRes.Operation = oper;

                        yield return new UserFavoriteResult()
                        {
                            Id = Id,
                            User = user,
                            Result = operRes
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
    }
}
