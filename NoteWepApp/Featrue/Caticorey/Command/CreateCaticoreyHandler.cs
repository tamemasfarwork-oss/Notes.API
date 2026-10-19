using Notes.DAL.Data;
using Notes.DAL.Entity;

namespace NoteWepApp.Featrue.Caticorey.Command
{
    public class CreateCaticoreyHandler
    {

        readonly private AppDbContext _context;

        public CreateCaticoreyHandler(AppDbContext appDbContext) => _context = appDbContext;


        public async Task<Guid> Hnadel(CreateCaticoreyCommand createCaticoreyCommand,CancellationToken ct)
        {
            var newcarti = new Categories
            {
                is_pinned = createCaticoreyCommand.is_pinned,
                title=createCaticoreyCommand.title,
            };
            var add = await _context.Categories.AddAsync(newcarti);

            var result = await _context.SaveChangesAsync(ct);
            return newcarti.categoriesID;


        }
    }
}
