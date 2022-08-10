using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Podify.Entities
{
    public class Podcast
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string PodcastHostId { get; set; } //FK Host
        public virtual PodcastHost PodcastHost { get; set; } //1-1
        public virtual ICollection<Episode> Episodes { get; set; } //1-M
    }
}
