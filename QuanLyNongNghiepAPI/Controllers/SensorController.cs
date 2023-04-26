using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QuanLyNongNghiepAPI.Controllers
{
    [Route("API/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        // GET: api/<SensorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SensorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SensorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SensorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SensorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
