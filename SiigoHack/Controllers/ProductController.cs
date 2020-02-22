using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BL.ProductBL;
using ET.ProductET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiigoHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBL _productProvider;


        public ProductController(IProductBL pProductBL)
        {
            _productProvider = pProductBL;
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {            
            try
            {
                return await _productProvider.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(null);
            }
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
