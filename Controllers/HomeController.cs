using Horizon.Repository.ECW;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalRecordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = $@"
        SELECT 
            CONCAT(u.ufname, ' ', u.ulname) AS FullName,
            u.dob
        FROM users u
        LEFT JOIN patients p 
            ON p.pid = u.uid
        WHERE p.ControlNo = {id};";

            var results = new ECWDB().RunQuery(query);
            //var r = new ().RunQuery(query);

            if (results == null || results.Rows.Count == 0)
                return NotFound("No patient found for the given control number.");

            var row = results.Rows[0];
            var patient = new
            {
                Name = row["FullName"].ToString(),
                DOB = Convert.ToDateTime(row["dob"]).ToString("yyyy-MM-dd")
            };

            return Ok(patient);
        }


        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
