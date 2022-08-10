using Podify.Entities;
using Podify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Repositories
{
    public interface IPodcastHostsRepository
    {
        IQueryable<PodcastHost> GetPodcastHostsIQueriable();
        void Create(PodcastHost host);
        void Update(PodcastHost host);
        void Delete(PodcastHost host);

        IQueryable<PodcastHostPodcast> GetJoin();

    }
}
