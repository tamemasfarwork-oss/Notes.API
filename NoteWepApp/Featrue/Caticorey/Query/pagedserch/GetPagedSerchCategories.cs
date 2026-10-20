using Microsoft.EntityFrameworkCore;
using Notes.DAL.Data;
using Notes.DAL.Entity;
using System.Linq.Expressions;

namespace NoteWepApp.Featrue.Caticorey.Query.pagedserch
{
    public class GetPagedSerchCategories
    {

        readonly private AppDbContext _context;

        public GetPagedSerchCategories(AppDbContext appDbContext) => _context = appDbContext;

        public async Task<List<CategoriesListserch>> GetCategories(CancellationToken ct
            ,int take , string? term)
        {
            var query = _context.Categories.AsNoTracking().AsQueryable();
            if (!string.IsNullOrEmpty(term)){
                query = query.Where(s => s.title!.Contains(term));
            }
            return await query.OrderBy(s => s.title)
                .Take(take)
                .Select(s => new CategoriesListserch (s.title!,s.categoriesID))
                
                .ToListAsync();
        }
        

    }
}
