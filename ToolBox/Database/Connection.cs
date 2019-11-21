using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Database
{
    public class Connection
    {
        private readonly string _ConnectionString;

        public Connection(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<SqlDataReader, TResult> selector)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                {
                    connection.Open();

                    using (SqlDataReader dataReader = cmd.ExecuteReader())
                    {
                        List<TResult> items = new List<TResult>();
                        while (dataReader.Read())
                        {
                            items.Add(selector(dataReader));
                        }

                        return items;
                    }
                }
            }
        }

        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            { 
                using (SqlCommand cmd = CreateCommand(command, connection))
                {   
                    connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }        

        public object ExecuteScalar(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand cmd = CreateCommand(command, connection))
                { 
                    connection.Open();
                    object o = cmd.ExecuteScalar();
                    return (o is DBNull) ? null : o;
                }
            }
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _ConnectionString;
            return connection;
        }

        private SqlCommand CreateCommand(Command command, SqlConnection connection)
        {
            SqlCommand cmd = connection.CreateCommand();
        
            cmd.CommandText = command.Query;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }

            return cmd;
        }
    }
}
