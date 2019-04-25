using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Web.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingCart.Web.Controllers
{
    [Route("calculator")]
    public class CalculatorController : Controller
    {
        // GET: calculator/totalCost
        [HttpGet("{}")]
        public ObjectResult GetTotalCost(List<ShoppingItem> shoppingItems)
        {
            return new OkObjectResult(5);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
