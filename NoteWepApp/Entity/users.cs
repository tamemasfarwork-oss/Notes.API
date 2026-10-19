using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.DAL.Entity
{
    public class Users
    {
        public Guid userid { get; set; } = Guid.NewGuid();
        public string passwordhash { get; set; } = null!;
        public string user_name { get; set; } = null!;
        public string? email { get; set; } = null!;

        //public ICollection<Note>? Note { get; set; } = new List<Note>();
        //public ICollection<Categories>? Categories { get; set; } = new List<Categories>();
        //public ICollection<Image>? images { get; set; } = new List<Image>();

    }
}
