using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Entity
{
    public class Categories
    {
        public Guid categoriesID { get; set; } = Guid.NewGuid();

        public string? title { get; set; }
        public bool is_pinned { get; set; } = false;
        public ICollection<Note>? notes { get; set; } = new List<Note>();
        //public Guid userid { get; set; }
        //public Users users { get; set; }
    }
}
