using Notes.DAL.Data;
using Notes.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Featrue.User.Command.createuser
{
    public class CreateUserHandler
    {

        readonly private AppDbContext _context;

        public CreateUserHandler(AppDbContext appDbContext) => _context = appDbContext;
       

        public  async Task<Guid>Handel(CreateUserCommand createUser,CancellationToken ct)
        {
            var newuser = new Users
            {
                user_name = createUser.user_name,
                email =createUser.email,
                passwordhash=createUser.passwordhash
            };
            var add =  await _context.AddAsync(newuser);
            var result =  await _context.SaveChangesAsync(ct);
            return newuser.userid;
        }
    }
}
