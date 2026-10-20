using Microsoft.AspNetCore.Mvc;
using NoteWepApp.Featrue.Caticorey.Query;
using NoteWepApp.Featrue.Note.Command;
using NoteWepApp.Featrue.Note.Query.GetNoteBycaidQuery;

namespace NoteWepApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : Controller
    {
        private readonly CreateNoteHandler _createNote;

        public NoteController(CreateNoteHandler createNote)
        {
            _createNote = createNote;
        }

        [HttpPost("CreateNote")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateNote([FromForm] CreateNoteCommand command, CancellationToken ct)
        {
            try
            {
                var id = await _createNote.Handle(command, ct);
                return Ok(new { notesID = id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet("GetByCategory/{categoryId:guid}")]
        public async Task<IActionResult> GetByCategory([FromServices] GetNoteBycaidHandler createNoteHandler,Guid categoryId, CancellationToken ct)
        {
            var notes = await createNoteHandler.Handle(categoryId, ct);
            return Ok(notes);
        }
    }
}
    
