﻿using NectarWeb.Models;
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
    private const string ConnectionString = "Data Source=ZENPORT30;Database=Nectar;User Id=francois;Integrated Security=True;";
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
      using (var command = new SqlCommand($"SELECT * FROM Beekeeper WHERE ZipCode like '{postalCode.Substring(0, 2)}%'", Connection))
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
  }
}