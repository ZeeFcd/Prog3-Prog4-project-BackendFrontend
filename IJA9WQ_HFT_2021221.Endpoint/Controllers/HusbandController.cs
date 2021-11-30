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
    public class HusbandController : ControllerBase
    {
        IHusbandLogic hl;
        public HusbandController(IHusbandLogic hl)
        {
            this.hl = hl;
        }

        // GET: /husband
        [HttpGet]
        public IEnumerable<Husband> Get()
        {
            return hl.ReadAll();
        }

        // GET /husband/5
        [HttpGet("{id}")]
        public Husband Get(int id)
        {
            return hl.Read(id);
        }

        // POST /husband
        [HttpPost]
        public void Post([FromBody] Husband value)
        {
            hl.Create(value);
        }

        // PUT /husband
        [HttpPut]
        public void Put([FromBody] Husband value)
        {
            hl.Update(value);
        }

        // DELETE /husband/5 MINDIG WEddinGET KELL ELŐSZőr törölni aztán husbandet és aztán wifeot
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            hl.Delete(id);
        }
    }
}
