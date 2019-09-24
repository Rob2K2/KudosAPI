using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudosAPI.DB;
using KudosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using RestSharp;

namespace KudosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KudosController : ControllerBase
    {
        private readonly Connection db = new Connection("db_kudos");

        [HttpGet]
        public ActionResult<IEnumerable<Kudos>> Get()
        {
            var listado = db.LoadRecords<Kudos>("Kudos");

            return listado;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }


        //Create Kudos
        [HttpPost]
        public IActionResult Post([FromBody] Kudos kudos)
        {
            db.InsertRecord("Kudos", kudos);

            UpdateKudos(kudos.Destino, "add");

            return Ok(kudos);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        //Delete Kudos
        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromBody] Kudos kudos)
        {
            db.DeleteRecord<Kudos>("Kudos", ObjectId.Parse(id));

            UpdateKudos(kudos.Destino, "dec");

            return Ok();
        }

        private void UpdateKudos(string destino, string option)
        {
            var client = new RestClient("http://localhost:57359/api/stats/" + option);
            var request = new RestRequest(Method.PUT);

            string json = "{\"userID\":\"" + destino + "\"}";

            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var response = client.Execute(request);
        }
    }
}
