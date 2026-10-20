using Microsoft.EntityFrameworkCore;
using Notes.DAL.Data;
using Notes.DAL.Entity;

namespace NoteWepApp.Featrue.Note.Command
{
    public class CreateNoteHandler
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
        private const long MaxFileSize = 5 * 1024 * 1024;

        public CreateNoteHandler(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(request.title) && string.IsNullOrWhiteSpace(request.content))
                throw new ArgumentException("لازم تكتب عنوان أو محتوى");

            var categoryExists = await _db.Categories
                .AnyAsync(c => c.categoriesID == request.CatigoryID, ct);

            if (!categoryExists)
                throw new ArgumentException("التصنيف غير موجود");

            var files = request.images ?? new List<IFormFile>();

            foreach (var file in files)
            {
                var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!AllowedExtensions.Contains(ext))
                    throw new ArgumentException($"نوع الملف غير مسموح: {file.FileName}");
                if (file.Length > MaxFileSize)
                    throw new ArgumentException($"الصورة أكبر من خمسة ميغا: {file.FileName}");
            }

            var note = new Notes.DAL.Entity.Note
            {
                title = request.title,
                content = request.content,
               
                CatigoryID = request.CatigoryID,
            };

            var webRoot = _env.WebRootPath ?? Path.Combine(_env.ContentRootPath, "wwwroot");
            var folder = Path.Combine(webRoot, "images", "notes");
            Directory.CreateDirectory(folder);

            var savedPaths = new List<string>();

            try
            {
                foreach (var file in files)
                {
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName).ToLowerInvariant()}";
                    var fullPath = Path.Combine(folder, fileName);

                    await using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream, ct);
                    }

                    savedPaths.Add(fullPath);
                    note.images.Add(new Image { pathimage = $"/images/notes/{fileName}" });
                }

                _db.Note.Add(note);
                await _db.SaveChangesAsync(ct);

                return note.notesID;
            }
            catch
            {
                foreach (var path in savedPaths)
                    if (File.Exists(path)) File.Delete(path);
                throw;
            }
        }
    }
}
    