using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Podify.Entities;

namespace Podify.Repositories
{
    public interface IGuestsRepository
    {
        IQueryable<Guest> GetGuestsIQueriable();

        IQueryable<EpisodeGuest> GetGuestsEpisodes(); 
        void Create(Guest guest);
        void Update(Guest guest);
        void Delete(Guest guest);
    }
}
