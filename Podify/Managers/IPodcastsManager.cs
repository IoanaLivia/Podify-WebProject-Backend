using Podify.Entities;
using Podify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public interface IPodcastsManager
    {
        List<Podcast> GetPodcasts();
        Podcast GetPodcastById(string id);

        void Create(PodcastCreationModel model);
        void Update(PodcastCreationModel model);
        void Delete(string id);

    }
}
