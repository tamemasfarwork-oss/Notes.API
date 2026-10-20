using Microsoft.EntityFrameworkCore;
using Notes.DAL.Data;

namespace NoteWepApp.Featrue.Caticorey.Query
{
    public class GetCategoriesHandel
    {
        readonly private AppDbContext _context;

        public GetCategoriesHandel(AppDbContext appDbContext) => _context = appDbContext;


        public async Task<List<CategoriesListItems>> GetCategories(CancellationToken ct)
        {
            return await _context.Categories
                .AsNoTracking()
                .Select(s => new CategoriesListItems(s.title!, s.categoriesID,s.is_pinned))
                .ToListAsync(ct);
        }

    }
}
