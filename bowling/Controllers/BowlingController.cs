using Microsoft.AspNetCore.Mvc;

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
