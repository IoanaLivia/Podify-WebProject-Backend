using Podify.Entities;
using Podify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public interface IPodcastHostsManager
    {
        List<PodcastHost> GetPodcastHosts();
        PodcastHost GetPodcastHostById(string id);

        void Create(PodcastHostCreationModel model);
        void Update(PodcastHostCreationModel model);
        void Delete(string id);

        List<PodcastHostPodcast> Join();
    }
}
