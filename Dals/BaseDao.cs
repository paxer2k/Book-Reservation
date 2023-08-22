using Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Web;

namespace Dals
{
    public abstract class BaseDao
    {
        private MySqlConnection dbConnection;
        protected BaseDao()
        {
            string connectionString = Settings.Default.MyDbConnection;
            dbConnection = new MySqlConnection(connectionString);
        }

        protected MySqlConnection OpenConnection()
        {
            try
            {
                if (dbConnection.State != System.Data.ConnectionState.Open)
                    dbConnection.Open();
            }
            catch(Exception ex)
            {
                throw;
            }


            return dbConnection;
        }

        protected void CloseConnection()
        {
            dbConnection.Close();
        }

        protected List<T> GetAll<T>(string query, Func<MySqlDataReader, T> readFunc)
        {
            dbConnection = OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query, dbConnection);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<T> items = new List<T>();

            while (reader.Read())
            {
                T item = readFunc(reader);
                items.Add(item);
            }

            reader.Close();
            CloseConnection();

            return items;
        }

        protected T GetOne<T>(int id, string query, Func<MySqlDataReader, T> readFunc)
        {
            dbConnection = OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query, dbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            MySqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                T item = readFunc(dr);
                dr.Close();
                return item;
            }
            else
            {
                dr.Close();
                return default(T); // Return default value for T if no record is found.
            }
        }

        protected List<T> GetAllByOne<T>(Dictionary<string, object> parameters, string query, Func<MySqlDataReader, T> readFunc)
        {
            dbConnection = OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query, dbConnection);

            foreach (var parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            MySqlDataReader dr = cmd.ExecuteReader();

            List<T> items = new List<T>();

            while (dr.Read())
            {
                T result = readFunc(dr);
                items.Add(result);
            }

            dr.Close();
            CloseConnection();

            return items;
        }

        protected void InsertOne(Dictionary<string, object> parameters, string query)
        {
            dbConnection = OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query, dbConnection);

            foreach (var parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Insertion was successful!");
            }
            else
            {
                Console.WriteLine("Insertion failed.");
            }

            CloseConnection();
        }

        protected void UpdateOne(Dictionary<string, object> parameters, string query)
        {
            dbConnection = OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query, dbConnection);

            foreach (var parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Update was successful!");
            }
            else
            {
                Console.WriteLine("Update failed.");
            }

            CloseConnection();
        }

        protected void DeleteOne(Dictionary<string, object> parameters, string query)
        {
            dbConnection = OpenConnection();

            MySqlCommand cmd = new MySqlCommand(query, dbConnection);

            foreach (var parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("Deletion was successful!");
            }
            else
            {
                Console.WriteLine("Deletion failed.");
            }
        }


        protected Customer ReadCustomer(MySqlDataReader dr)
        {
            return new Customer((int)dr["ID"], (string)dr["FIRSTNAME"], (string)dr["LASTNAME"], (string)dr["EMAILADDRESS"]);
        }

        protected Book ReadBook(MySqlDataReader dr)
        {
            return new Book((int)dr["ID"], (string)dr["TITLE"], (string)dr["AUTHOR"]);
        }

        protected Reservation ReadReservation(MySqlDataReader dr)
        {
            int reservationID = (int)dr["RESERVATIONID"];
            int customerID = (int)dr["CUSTOMERID"];
            string firstName = (string)dr["FIRSTNAME"];
            string lastName = (string)dr["LASTNAME"];
            string emailAddress = (string)dr["EMAILADDRESS"];
            int bookID = (int)dr["BOOKID"];
            string title = (string)dr["TITLE"];
            string author = (string)dr["AUTHOR"];

            Customer customer = new Customer(customerID, firstName, lastName, emailAddress);
            Book book = new Book(bookID, title, author);

            return new Reservation(reservationID, customer, book);
        }
    }
}
