using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;



namespace bowling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
     
        [HttpPost]
        public ActionResult GetBowlingMark([FromBody] payload pinDowned) 
        {   
            BowlingRepo b = new BowlingRepo();

            if (pinDowned == null)
            {
                return NotFound();
            }

            return Ok(b.GetMark(pinDowned));
            
        }

    }
}
