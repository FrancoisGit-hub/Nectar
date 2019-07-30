namespace NctAPI.DAL
{
    /// <summary>
    /// DB queries class
    /// </summary>
    public static class NectarQueries
    {
        // Constant queries
        #region Constants
        /// <summary>
        /// Return the ten first cities
        /// </summary>
        internal static readonly string GetCities = "SELECT TOP 10 Id, CityCode, Label, CP, RoutingLabel, FifthLine, Department FROM City";

        /// <summary>
        /// Return the first city
        /// </summary>
        internal static readonly string GetCity = "SELECT TOP 1 Id, CityCode, Label, CP, RoutingLabel, FifthLine, Department FROM City";
        #endregion
    }
}