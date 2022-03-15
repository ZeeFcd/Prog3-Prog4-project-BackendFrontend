using IJA9WQ_HFT_2021221.Endpoint.Services;
using IJA9WQ_HFT_2021221.Logic;
using IJA9WQ_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public HusbandController(IHusbandLogic hl, IHubContext<SignalRHub> hub)
        {
            this.hl = hl;
            this.hub = hub;
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
            hub.Clients.All.SendAsync("HusbandCreated",value);
        }

        // PUT /husband
        [HttpPut]
        public void Put([FromBody] Husband value)
        {
            hl.Update(value);
            hub.Clients.All.SendAsync("HusbandUpdated", value);
        }

        // DELETE /husband/5 MINDIG WEddinGET KELL ELŐSZőr törölni aztán husbandet és aztán wifeot
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var husbandToDelete = hl.Read(id);
            hl.Delete(id);
            hub.Clients.All.SendAsync("HusbandDeleted", husbandToDelete);
        }
    }
}
