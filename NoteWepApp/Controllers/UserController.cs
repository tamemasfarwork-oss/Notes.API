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
        readonly private CreateUserHandler _hanel;


        public UserController(CreateUserHandler createUserHandler) => _hanel = createUserHandler;

        [HttpPost]
        public async Task<IActionResult> Create(
          CreateUserCommand cmd,
          CancellationToken ct)
        {
            // التحقق من المدخلات قبل أي عمل
            

            // تسليم الأمر للمعالج، ثم الرد برقم السجل
            var id = await _hanel.Handel(cmd, ct);
            return Created($"/notes/{id}", new { id });
        }
    }
}
