using IJA9WQ_HFT_2021221.Logic;
using IJA9WQ_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IJA9WQ_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WifeController : ControllerBase
    {
        IWifeLogic wl;
        public WifeController(IWifeLogic wl)
        {
            this.wl = wl;
        }

        // GET: /wife
        [HttpGet]
        public IEnumerable<Wife> Get()
        {
            return wl.ReadAll();
        }

        // GET /wife/5
        [HttpGet("{id}")]
        public Wife Get(int id)
        {
            return wl.Read(id);
        }

        // POST /wife
        [HttpPost]
        public void Post([FromBody] Wife value)
        {
            wl.Create(value);
        }

        // PUT /wife
        [HttpPut]
        public void Put([FromBody] Wife value)
        {
            wl.Update(value);
        }

        // DELETE /wife/5   MINDIG WEddinGET KELL ELŐSZőr törölni aztán husbandet és aztán wifeot
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            wl.Delete(id);
        }
    }
}
