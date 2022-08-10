using Podify.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Podify.Repositories
{
    public interface IEpisodesRepository
    {
        IQueryable<Episode> GetEpisodesIQueriable();
        IQueryable<EpisodeGuest> GetEpisodesGuests();
        void Create(Episode episode);
        void Update(Episode episode);
        void Delete(Episode episode);
    }
}

