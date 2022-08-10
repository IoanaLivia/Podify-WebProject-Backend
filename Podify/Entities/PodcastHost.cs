using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Entities
{
    public class PodcastHost
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }

        public virtual Podcast Podcast { get; set; } //1-1
    }
}
