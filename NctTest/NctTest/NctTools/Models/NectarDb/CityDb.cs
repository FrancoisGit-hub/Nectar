namespace NctTools.Models.NectarDb
{
    /// <summary>
    /// City entity class
    /// </summary>
    public class CityDb
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// City code
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Postal code
        /// </summary>
        public string CP { get; set; }

        /// <summary>
        /// To be defined
        /// </summary>
        public string RoutingLabel { get; set; }

        /// <summary>
        /// To be defined
        /// </summary>
        public string FifthLine { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Lng { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Departement (french specific)
        /// </summary>
        public string Department { get; set; }
    }
}
