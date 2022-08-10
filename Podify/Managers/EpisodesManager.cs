using Podify.Entities;
using Podify.Models;
using Podify.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public class EpisodesManager : IEpisodesManager
    {
        private readonly IEpisodesRepository episodesRepository;

        public EpisodesManager(IEpisodesRepository episodesRepository)
        {
            this.episodesRepository = episodesRepository;
        }

        public List<Episode> GetEpisodes()
        {
            return episodesRepository.GetEpisodesIQueriable().ToList();
        }

        public Episode GetEpisodeById(string id)
        {
            var episode = episodesRepository
                  .GetEpisodesIQueriable()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
            return episode;
        }

        public void Create(EpisodeCreationModel model)
        {
            var newEpisode = new Episode
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
                Realeased = model.Realeased,
                PodcastId = model.PodcastId
            };

            episodesRepository.Create(newEpisode);
        }
        public void Update(EpisodeCreationModel model)
        {
            var newEpisode = GetEpisodeById(model.Id);
            newEpisode.Id = model.Id;
            newEpisode.Title = model.Title;
            newEpisode.Description = model.Description;
            newEpisode.ReleaseDate = model.ReleaseDate;
            newEpisode.Realeased = model.Realeased;
            newEpisode.PodcastId = model.PodcastId;

            episodesRepository.Update(newEpisode);
        }

        public void Delete(string id)
        {
            var newEpisode = GetEpisodeById(id);

            episodesRepository.Delete(newEpisode);
        }

        //episoadele in care apare un guest
        public List<EpisodeGuest> GetGuestEpisodes(string id)
        {
            var guestsepisodes = episodesRepository.GetEpisodesGuests().ToList();
            var guestepisodes = guestsepisodes.Where(x => x.EpisodeId == id).ToList();
            return guestepisodes;
        }
    }
}

