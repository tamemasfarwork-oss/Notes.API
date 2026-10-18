using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Entity
{
    public class Image
    {
        public Guid imageID { get; set; } = Guid.NewGuid();
        public string pathimage { get; set; }

        public Guid  noteID { get; set; }
        public Note note { get; set; } = null!;
        public Guid userid { get; set; }
        public Users users { get; set; }

    }
}
