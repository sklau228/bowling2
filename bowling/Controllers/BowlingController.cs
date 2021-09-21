using Microsoft.AspNetCore.Mvc;

namespace scores.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class scoresController : ControllerBase
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
