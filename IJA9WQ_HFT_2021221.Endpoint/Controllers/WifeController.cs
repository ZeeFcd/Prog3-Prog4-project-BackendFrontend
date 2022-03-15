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
    public class WifeController : ControllerBase
    {
        IWifeLogic wl;
        IHubContext<SignalRHub> hub;
        public WifeController(IWifeLogic wl, IHubContext<SignalRHub> hub)
        {
            this.wl = wl;
            this.hub=hub;
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
            hub.Clients.All.SendAsync("WifeCreated", value);
        }

        // PUT /wife
        [HttpPut]
        public void Put([FromBody] Wife value)
        {
            wl.Update(value);
            hub.Clients.All.SendAsync("WifeUpdated", value);
        }

        // DELETE /wife/5   MINDIG WEddinGET KELL ELŐSZőr törölni aztán husbandet és aztán wifeot
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var wifeToDelete = wl.Read(id);
            wl.Delete(id);
            hub.Clients.All.SendAsync("WifeDeleted", wifeToDelete);
        }
    }
}
