using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels.Models;
using System.Data.SqlClient;

namespace DomainModels.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private string conString;

        public OperationRepository(string conString)
        {
            this.conString = conString;
        }

        public void Insert(Operation oper)
        {
            try
            {
                using (var connection = new SqlConnection(conString))
                {
                    SqlCommand command = new SqlCommand(@"Insert into Operation(Uid,Name, FullName) values(" + Guid.NewGuid() + "," + oper.Name + "," + oper.FullName + ");");
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete(Operation oper)
        {
            try
            {
                using (var connection = new SqlConnection(conString))
                {

                    SqlCommand command = new SqlCommand("Delete from Operation where Uid=" + oper.Uid + ";", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Operation Get(int id)
        {
            try
            {
                using (var connection = new SqlConnection(conString))
                {

                    SqlCommand command = new SqlCommand("SELECT Id, Uid, Name, FullName FROM Operation where Id = " + id + ";", connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Operation t = new Operation();
                    if (reader.HasRows)
                    {

                        reader.Read();
                        t.Id = reader.GetInt64(0);
                        t.Uid = reader.GetGuid(1);
                        t.Name = reader.GetString(2);
                        t.FullName = reader.GetString(3);
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

        public IEnumerable<Operation> GetAll()
        {
            using (var connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Name, FullName FROM Operation;", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var id = reader.GetInt64(0);
                        var Name = reader.GetString(1);
                        var FullName = reader.GetString(2);

                        yield return new Operation()
                        {
                            Id = id,
                            Name = Name,
                            FullName = FullName
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

        public void Update(Operation user)
        {
            throw new NotImplementedException();
        }
    }
}
