using Microsoft.AspNetCore.Mvc;
using Notes.DAL.Featrue.User.Command.createuser;
using NoteWepApp.Featrue.Caticorey.Command;

namespace NoteWepApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CateicoreyController : Controller
    {
        [HttpPost("createca")]
        public async Task<IActionResult> Createca(
                     CreateCaticoreyCommand cmd,
         [FromServices] CreateCaticoreyHandler handel,
          CancellationToken ct)
        {
            // التحقق من المدخلات قبل أي عمل


            // تسليم الأمر للمعالج، ثم الرد برقم السجل
            var id = await handel.Hnadel(cmd, ct);
            return Created($"/notes/{id}", new { id });
        }
    }
}
