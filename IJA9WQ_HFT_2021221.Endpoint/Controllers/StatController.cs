using IJA9WQ_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IWeddingLogic wedl;

        public StatController(IWeddingLogic wedl)
        {
            this.wedl = wedl;
        }

        // GET: /stat/MarriedCouples
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> MarriedCouples()
        {
            return wedl.MarriedCouples();
        }

        // GET: /stat/WeddingPlacesByWife
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> WeddingPlacesByWife()
        {
            return wedl.WeddingPlacesByWife();
        }

        // GET: /stat/WeddingPricesByHusband
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> WeddingPricesByHusband()
        {
            return wedl.WeddingPricesByHusband();
        }

        // GET: /stat/AverageAge
        [HttpGet]
        public double AverageAge()       
        {
            return wedl.AverageAge();
        }

        // GET: /stat/WifeWhereHusbandIsOldest
        [HttpGet]
        public string WifeWhereHusbandIsOldest()
        {
            return wedl.WifeWhereHusbandIsOldest();
        }               


    }
}
