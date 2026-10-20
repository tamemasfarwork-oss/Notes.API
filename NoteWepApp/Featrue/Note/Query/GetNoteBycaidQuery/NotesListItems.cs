namespace NoteWepApp.Featrue.Note.Query.GetNoteBycaidQuery
{
    public record NotesListItems(
        Guid notesID,
        string? title,
        string? content,
        bool is_pinned,
        bool should_review_it,
        List<string> images
    );

}
