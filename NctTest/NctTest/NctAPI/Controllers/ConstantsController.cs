using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NctAPI.DAL;
using NctTools.Models;
using NctTools.Models.NectarDb;
using System;
using System.Collections.Generic;

namespace NctAPI.Controllers
{
    /// <summary>
    /// Class returning constant data
    /// </summary>
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class ConstantsController : ControllerBase
    {
        /// <summary>
        /// Will return the cities from the application, limited to 10
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCities")]
        public APIResult<List<CityDb>> GetCities()
        {
            try
            {
                using (var dal = new NectarDAL())
                {
                    List<CityDb> cities = dal.GetCities();
                    return new APIResult<List<CityDb>>(cities);
                }
            }
            catch (Exception e)
            {
                return new APIResult<List<CityDb>>(e);
            }
        }
    }
}