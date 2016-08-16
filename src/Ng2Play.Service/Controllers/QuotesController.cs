using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ng2Play.Service.Controllers
{
    public class QuotesController : Controller
    {
        public QuotesController(IHostingEnvironment env) 
        {
            this.Environment = env;
        }
        public IHostingEnvironment Environment { get; }
        // GET api/quote
        [HttpGet]
        [Route("api/quote")]
        public IActionResult GetQuote()
        {
            string path = Path.Combine(Environment.ContentRootPath, "Data", "quotes.json");
            if (System.IO.File.Exists(path) == true)
            {
                using (StreamReader reader = System.IO.File.OpenText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    IEnumerable<string> quotes = (IEnumerable<string>)serializer.Deserialize(reader, typeof(IEnumerable<string>));
                    int randomIndex = new Random().Next(0, quotes.Count());
                    return Ok(quotes.ElementAt(randomIndex));
                }
            }
            return NotFound();
        }

    }
}
