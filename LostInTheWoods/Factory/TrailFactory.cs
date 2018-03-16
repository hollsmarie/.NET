using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using LostInTheWoods.Models;
 
namespace LostInTheWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private string connectionString;
        public TrailFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=TheWoods;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
     public void Add(Trail item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO Trails (Name, Description, Length, Elevation, Latitude, Longitude) VALUES (@Name, @Description, @Length, @Elevation, @Latitude, @Longitude)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM Trails");
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trails WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
            
                string query = ("DELETE FROM trails WHERE id = " + id.ToString());
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
    }
}
