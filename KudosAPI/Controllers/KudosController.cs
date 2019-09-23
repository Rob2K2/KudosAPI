using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KudosAPI.DB;
using KudosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

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

        [HttpPost]
        public IActionResult Post([FromBody] Kudos kudos)
        {
            db.InsertRecord("Kudos", kudos);

            return Ok(kudos);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            db.DeleteRecord<Kudos>("Kudos", ObjectId.Parse(id));

            return Ok();
        }
    }
}
