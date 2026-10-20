namespace NoteWepApp.Featrue.Note.Command
{
    public record CreateNoteCommand(
          string? title,
          string? content,
         
          Guid CatigoryID,
          List<IFormFile>? images
      ) ;
}
