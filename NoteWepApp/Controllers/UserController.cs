using Microsoft.AspNetCore.Mvc;
using Notes.DAL.Entity;
using Notes.DAL.Featrue;
using Notes.DAL.Featrue.User.Command.createuser;

namespace NoteWepApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        

        [HttpPost]
        public async Task<IActionResult> Create(
         [FromServices] CreateUserCommand cmd,
         [FromServices] CreateUserHandler handel,
          CancellationToken ct)
        {
            // التحقق من المدخلات قبل أي عمل
            

            // تسليم الأمر للمعالج، ثم الرد برقم السجل
            var id = await handel.Handel(cmd, ct);
            return Created($"/notes/{id}", new { id });
        }
    }
}
