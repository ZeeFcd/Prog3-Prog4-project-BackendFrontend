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
    public class WeddingController : ControllerBase
    {
        IWeddingLogic wedl;
        public WeddingController(IWeddingLogic wedl)
        {
            this.wedl = wedl;
        }

        // GET: /wedding
        [HttpGet]
        public IEnumerable<Wedding> Get()
        {
            return wedl.ReadAll();
        }

        // GET /wedding/5
        [HttpGet("{id}")]
        public Wedding Get(int id)
        {
            return wedl.Read(id);
        }

        // POST /wedding
        [HttpPost]
        public void Post([FromBody] Wedding value)
        {
            wedl.Create(value);
        }

        // PUT /wedding
        [HttpPut]
        public void Put([FromBody] Wedding value)
        {
            wedl.Update(value);
        }

        // DELETE /wedding/5 MINDIG WEddinGET KELL ELŐSZőr törölni aztán husbandet és aztán wifeot
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            wedl.Delete(id);
        }
    }
}
