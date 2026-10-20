using Microsoft.AspNetCore.Mvc;
using Notes.DAL.Featrue.User.Command.createuser;
using NoteWepApp.Featrue.Caticorey.Command;
using NoteWepApp.Featrue.Caticorey.Query;
using NoteWepApp.Featrue.Caticorey.Query.pagedserch;

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

        [HttpGet("GetCate")]
        public async Task<IActionResult> GetC(
                      
         [FromServices] GetCategoriesHandel handel,
          CancellationToken ct)
        {
            // التحقق من المدخلات قبل أي عمل


            // تسليم الأمر للمعالج، ثم الرد برقم السجل
            var items = await handel.GetCategories( ct);
            return items != null ? Ok(items) : BadRequest();
        }


        [HttpGet("Serch")]
        public async Task<IActionResult> Serch([FromServices]GetPagedSerchCategories cmd ,string serch , int take, CancellationToken ct)
        {
            var items = await cmd.GetCategories(ct, take, serch);
            return items != null ? Ok(items) : Ok(" no thing match");
        }
    }
}
