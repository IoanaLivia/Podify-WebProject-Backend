using Podify.Entities;
using Podify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Podify.Repositories
{
    public interface IPodcastsRepository
    {
        IQueryable<Podcast> GetPodcastsIQueriable();
        void Create(Podcast podcast);
        void Update(Podcast podcast);
        void Delete(Podcast podcast);
    }
}
