using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace OefeningWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetalController : ControllerBase
    {
        public GetalController()
        {

        }

        [HttpGet]
        public ActionResult<int> GetGetal()
        {
            try
            {
                int g = Convert.ToInt32(System.IO.File.ReadAllText("Getal.txt"));
                return Ok(g);
            } catch (Exception ex)
            {
                return NotFound();
            }
        }

        [HttpPost ("nieuw")]
        public ActionResult NewGetal(int getal)
        {
            try
            {
                string g = Convert.ToString(getal);

                System.IO.File.WriteAllText("Getal.txt", g);
                return Ok();
            } catch (Exception ex)
            {
                return NotFound();
            }
            
        }

        [HttpPost ("random")]
        public ActionResult RandomGetal()
        {
            Random r = new Random();

            int getal = r.Next(1, 10);

            System.IO.File.WriteAllText("Getal.txt", Convert.ToString(getal));

            return Ok();
        }
    }
}
