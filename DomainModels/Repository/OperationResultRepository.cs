using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    class OperationResultRepository : IOperationResultRepository
    {
        private string conString;

        public OperationResultRepository(string conString)
        {
            this.conString = conString;
        }

        public IEnumerable<OperationResult> GetAll()
        {
            using (var connection = new SqlConnection(conString))
            {

                SqlCommand command = new SqlCommand(@"SELECT Users.FIO, Operation.Name, Operation.FullName, OperationResult.InputData, OperationResult.Result, 
OperationResult.ExecutionTime, OperationResult.ExecutionDate FROM OperationResult INNER JOIN 
Operation on OperationResult.Operation=Operation.Id INNER JOIN Users on Users.Id=OperationResult.Author;", connection);
                connection.Open();


                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User author = new User();
                        author.FIO = reader.GetString(0);

                        Operation oper = new Operation();
                        oper.Name = reader.GetString(1);
                        oper.FullName = reader.GetString(2);


                        var InputData = reader.GetString(3);
                        var Result = reader.GetDouble(4);
                        var ExecutionTime = reader.GetInt32(5);
                        var ExecutionDate = reader.GetDateTime(6);


                        yield return new OperationResult()
                        {
                            Author = author,
                            Operation = oper,
                            InputData = InputData,
                            Result = Result,
                            ExecutionTime = ExecutionTime,
                            ExecutionDate = ExecutionDate
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
