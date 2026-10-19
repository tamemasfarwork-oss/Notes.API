
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoteWepApp.Featrue.Caticorey.Command
{
    public record CreateCaticoreyCommand(
          string title,
         bool is_pinned 
        );
    
    
}
