using Podify.Entities;
using Podify.Models;
using Podify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public interface IEpisodesManager
    {
        List<Episode> GetEpisodes();
        Episode GetEpisodeById(string id);
        List<EpisodeGuest> GetGuestEpisodes(string id);
        void Create(EpisodeCreationModel model);
        void Update(EpisodeCreationModel model);
        void Delete(string id);
    }
}
