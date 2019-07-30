using Microsoft.Extensions.Configuration;
using NctTools.Models.NectarDb;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NctAPI.DAL
{
    /// <summary>
    /// Data Access Layer class
    /// </summary>
    public class NectarDAL : IDisposable
    {
        /// <summary>
        /// Configuration
        /// </summary>
        private static IConfigurationRoot Configuration { get; set; }

        /// <summary>
        /// SQL connection
        /// </summary>
        private SqlConnection _connection;

        /// <summary>
        /// Connection string
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// Connection string name
        /// </summary>
        public string connectionStringName;

        #region Constructor(s)
        /// <summary>
        /// Constructor (open a new connection)
        /// </summary>
        public NectarDAL()
        {
            _connectionString = Startup.NectarConnectionString;
            Open();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Open a new connection
        /// </summary>
        public void Open()
        {
            if ((_connection == null) || (_connection.State != ConnectionState.Open))
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }
        }

        /// <summary>
        /// Close the connection
        /// </summary>
        public void Close()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// Revocate connection permanently
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();

        }
        #endregion

        #region Constant methods
        /// <summary>
        /// Obtain the ten first cities
        /// </summary>
        /// <returns></returns>
        public List<CityDb> GetCities()
        {
            List<CityDb> cities = new List<CityDb>();
            SqlCommand command = new SqlCommand(NectarQueries.GetCities, _connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var city = new CityDb()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Label = reader["Label"].ToString()
                    };
                    cities.Add(city);
                }
            }
            return cities;
        }
        #endregion
    }
}