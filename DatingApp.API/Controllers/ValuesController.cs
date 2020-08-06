using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Data;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    // controller = values
    // http:localhost:5000/api/values
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        // click on light bulb and select initialise field from parameter
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // get api values 
        [HttpGet]
        // IEnumberable means a collecion of strings in this case
        // this is changes to fetch values from db.
        public async Task<IActionResult> GetValues()
        {
          // goto db and fetch list of values set to async to allow other requests
            var values= await _context.Values.ToListAsync();
            return Ok(values);
        }
        // get api values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var value=await _context.Values.FirstOrDefaultAsync (x=>x.Id==id);
            return Ok(value);
        }

        // add new record
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // amend a value
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // delete api value
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }
}