using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Models
{
    public class PodcastCreationModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public string PodcastHostId { get; set; } //FK Host
    }
}
