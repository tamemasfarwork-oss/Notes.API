using Microsoft.EntityFrameworkCore;
using Notes.DAL.Data;

namespace NoteWepApp.Featrue.Note.Query.GetNoteBycaidQuery
{
    public class GetNoteBycaidHandler
    {
        private readonly AppDbContext _db;

        public GetNoteBycaidHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<NotesListItems>> Handle(
            Guid request, CancellationToken ct)
        {
            return await _db.Note
                .AsNoTracking()
                .Where(n => n.CatigoryID == request)
                .OrderByDescending(n => n.is_pinned)
                .Select(n => new NotesListItems(
                    n.notesID,
                    n.title,
                    n.content,
                    n.is_pinned,
                    n.should_review_it,
                    n.images.Select(i => i.pathimage).ToList()
                ))
                .ToListAsync(ct);
        }
    }
}

    