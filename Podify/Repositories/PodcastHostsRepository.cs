using Podify.Entities;
using Podify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Repositories
{
    public class PodcastHostsRepository : IPodcastHostsRepository
    {
        private readonly AppDbContext db;

        public PodcastHostsRepository(AppDbContext db)
        {
            this.db = db;
        }

        public IQueryable<PodcastHost> GetPodcastHostsIQueriable()
        {
            var host = db.PodcastHosts;
            return host;
        }

        public void Create(PodcastHost host)
        {
            db.PodcastHosts.Add(host);
            db.SaveChanges();
        }

        public void Update(PodcastHost host)
        {
            db.PodcastHosts.Update(host);
            db.SaveChanges();
        }

        public void Delete(PodcastHost host)
        {
            db.PodcastHosts.Remove(host);
            db.SaveChanges();
        }

        public IQueryable<PodcastHostPodcast> GetJoin()
        {
            var podcasthostpodcast = db.PodcastHosts.Join(db.Podcasts, podcastHost => podcastHost.Id, podcast => podcast.PodcastHostId,
                (podcasthost, podcast) => new PodcastHostPodcast
                {
                   HostName = podcasthost.Name,
                   PodcastName = podcast.Title
                });
            return podcasthostpodcast;
        }

    }
}

