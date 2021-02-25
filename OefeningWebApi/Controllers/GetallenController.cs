using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OefeningWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetallenController : ControllerBase
    {
        public GetallenController()
        {

        }


        // gaat alle elementen op de lijst weergeven
        [HttpGet]
        public ActionResult<int> GetGetal()
        {
            try
            {
                string[] g = System.IO.File.ReadAllLines("Getallen.txt");

                int[] getallen = Array.ConvertAll(g, s => int.Parse(s));

                return Ok(getallen);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // gaat getal dat gebruiker ingeeft mee in tekstbestand plaatsen
        [HttpPost("nieuw")]
        public ActionResult NewGetal(int getal)
        {
            try
            {
                string newContent = Convert.ToString(getal);

                System.IO.File.AppendAllText("Getallen.txt", newContent + Environment.NewLine);

                return Ok(getal);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            

        }

        // gaat random getal mee in tekstbestand plaatsen
        [HttpPost("random")]
        public ActionResult RandomGetal()
        {
            Random r = new Random();

            int getal = r.Next(1, 10);

            System.IO.File.AppendAllText("Getallen.txt", Convert.ToString(getal) + Environment.NewLine);

            return Ok();
        }

        // verwijdert de eerste lijn van het tekstbestand
        [HttpDelete]
        public ActionResult DeleteGetal()
        {


            string[] g = System.IO.File.ReadAllLines("Getallen.txt");

            List<string> getallenlijst = new List<string>();


            foreach (string element in g)
            {
                getallenlijst.Add(element);
            }



            getallenlijst.RemoveAt(0);

            using (StreamWriter writer = new StreamWriter("Getallen.txt"))
            {
                foreach (string getal in getallenlijst)
                {
                    writer.WriteLine(getal);
                }
            }

            

            return Ok(g);
        }
    }
}
