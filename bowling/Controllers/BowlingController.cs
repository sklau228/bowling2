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

            if (pinDowned.pinDowned is null)
            {
                return NotFound();
            }
            else
            {
                int[] p = pinDowned.pinDowned;
                if (p.Length > 12)
                {
                    return BadRequest("ttttt");
                }                
            }
            
            return Ok(b.GetMark(pinDowned));            
        }
    }
}
