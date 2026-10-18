using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Notes.DAL.Entity
{
    public class Note
    {
        public Guid notesID { get; set; } = Guid.NewGuid();
        public string? title { get; set; }
        public string? content { get; set; }
        public bool should_review_it { get; set; } = false;
        public bool is_pinned { get; set; } = false;
        public ICollection<Image>? images { get; set; } = new List<Image>();

        public Guid CatigoryID { get; set; }
        public Categories Categories = null!;

        public Guid userid { get; set; }
        public Users users { get; set; }

    }
}
