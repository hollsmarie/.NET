using System;
using DbConnection;

namespace CrudSQL_Assignment
{
    class Program
    {
        public static void read()
        {
           string query = "SELECT * from Users";
           var users = DbConnector.Query(query);
           foreach (var user in users)
           {
               System.Console.WriteLine (user["FirstName"] + " " + user["LastName"] + " " + user["FavoriteNumber"] + " " + user["id"]);
           }

        }

        public static void create()
        {
            System.Console.WriteLine("Please enter your first name:");
            string FirstName = "" + Console.ReadLine() + "";
            System.Console.WriteLine("Please enter your last name:");
            string LastName = "" + Console.ReadLine() + "";
            System.Console.WriteLine("Please enter your favorite number:");
            string FavoriteNumber = Console.ReadLine();
            string query = $"INSERT into Users(FirstName, LastName, FavoriteNumber) VALUES ({FirstName}, {LastName}, {FavoriteNumber})";
            System.Console.WriteLine(query);
            DbConnector.Execute(query);
            read();

        }

          static void Main(string[] args)
        {
           create();
        }
    }
}
