using NectarWeb.Models;
using NectarWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NectarWeb.DAL
{
    public class NectarDAL : IDisposable
    {
        //private const string ConnectionString = "Data Source=ZENPORT30;Database=Nectar;User Id=francois;Integrated Security=True;";
        private const string ConnectionString = "Data Source=SQL6010.site4now.net;Database=DB_A64FA6_Nectar;User Id=DB_A64FA6_Nectar_admin;password=8QbHcBKmLDrPi6C;Trusted_Connection=False;";
        private SqlConnection Connection;

        public NectarDAL()
        {
            Open();
        }

        private void Open()
        {
            if (Connection != null)
                Connection.Close();

            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        private void Close()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            Close();
        }

        public void SaveBeekeeperSubscription(BeekeeperSubscriptionView model)
        {
            Open();
            using (var command = new SqlCommand(@"declare @StrCity nvarchar(50)
      SELECT @StrCity = Label FROM City WHERE CP = '@ZipCode'
      INSERT INTO Beekeeper 
        (FirstName, LastName, Email, Phone1, CreatedDate, Origin, 
          ZipCode, StrCity) 
        VALUES (@FirstName, @LastName, @Email, @Phone1, GETDATE(), 2, 
          @ZipCode, @StrCity)", Connection))
            {
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@Phone1", model.PhoneNumber);
                command.Parameters.AddWithValue("@ZipCode", model.PostalCode);

                command.ExecuteNonQuery();
            }
        }

        public List<Beekeeper> GetBeekeepersByPostalCode(string postalCode)
        {
            Open();
            List<Beekeeper> results = new List<Beekeeper>();
            using (var command = new SqlCommand($"SELECT * FROM Beekeeper WHERE ZipCode = '{postalCode}'", Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var beeKeeper = new Beekeeper();
                        beeKeeper.Id = reader.GetInt32(reader.GetOrdinal("BeekeeperId"));
                        beeKeeper.FirstName = reader["FirstName"].ToString();
                        beeKeeper.LastName = reader["LastName"].ToString();
                        beeKeeper.ZipCode = reader["ZipCode"].ToString();
                        beeKeeper.City = reader["StrCity"].ToString().Replace("#VALEUR!", "");
                        beeKeeper.Email = reader["Email"].ToString();
                        beeKeeper.Phone = new string[]
                        {
              reader["Phone1"].ToString(),
              reader["Phone2"].ToString()
                        };
                        if (!beeKeeper.FirstName.Contains("#VALEUR!") && !beeKeeper.LastName.Contains("#VALEUR!"))
                            results.Add(beeKeeper);
                    }
                }
            }
            return results;
        }

        public List<Beekeeper> GetBeekeepersByDepartment(string dpt)
        {
            Open();
            List<Beekeeper> results = new List<Beekeeper>();
            using (var command = new SqlCommand($"SELECT * FROM Beekeeper WHERE ZipCode like '{dpt}%'", Connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var beeKeeper = new Beekeeper();
                        beeKeeper.Id = reader.GetInt32(reader.GetOrdinal("BeekeeperId"));
                        beeKeeper.FirstName = reader["FirstName"].ToString();
                        beeKeeper.LastName = reader["LastName"].ToString();
                        beeKeeper.ZipCode = reader["ZipCode"].ToString();
                        beeKeeper.City = reader["StrCity"].ToString().Replace("#VALEUR!", "");
                        beeKeeper.Email = reader["Email"].ToString();
                        beeKeeper.Phone = new string[]
                        {
              reader["Phone1"].ToString(),
              string.Empty
                        };
                        if (!beeKeeper.FirstName.Contains("#VALEUR!") && !beeKeeper.LastName.Contains("#VALEUR!"))
                            results.Add(beeKeeper);
                    }
                }
            }
            return results;
        }

        public List<Beekeeper> GetBeekeepersResultsByPostalCode(string postalCode)
        {
            List<Beekeeper> results = GetBeekeepersByPostalCode(postalCode);
            foreach (var b in GetBeekeepersByDepartment(postalCode.Substring(0, 2)))
            {
                var isAlreadyInresults = false;
                if (results.Count == 0)
                    results.Add(b);

                foreach (var r in results)
                {
                    if (r.Id == b.Id)
                    {
                        isAlreadyInresults = true;
                    }
                    if (!isAlreadyInresults)
                    {
                        results.Add(r);
                    }
                }
                return results;
            }
            return results;
        }
    }
}
