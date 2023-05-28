using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLib;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextAnalysisController : ControllerBase
    {
        [HttpPost(Name ="PostTextAnalysis")]
        public ActionResult<Dictionary<string,int>> GetActionResult([FromBody] string inpText)
        {
            return TextProcessing.myDicParallel(inpText);
        }

    }
}
