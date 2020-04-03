using GuildCars.Data.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class SearchVehiclesController : ApiController
    {
        
        [Route("api/Home/NewInventory")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNew(decimal? maxPrice, decimal? minPrice, int? maxYear, int? minYear, string text)
        {
            var repo = VehicleRepoFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear,
                    Text = text
                };

                var result = repo.SearchNewVehicles(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/Home/UsedInventory")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchOld(decimal? maxPrice, decimal? minPrice, int? maxYear, int? minYear, string text)
        {
            var repo = VehicleRepoFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    MinYear = minYear,
                    MaxYear = maxYear,
                    Text = text
                };

                var result = repo.SearchNewVehicles(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
