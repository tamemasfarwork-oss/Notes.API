using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Featrue.User.Command.createuser
{
    public record CreateUserCommand
   ( 
        int userid,
        string user_name,
        string? email
        , string passwordhash
          );
    
    
}
