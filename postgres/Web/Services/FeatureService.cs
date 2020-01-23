using System.Threading.Tasks;
using Postgres.Business.Entites.PacketAggregate;
using Postgres.Business.Interfaces;
using Postgres.Web.ViewModels;

namespace Postgres.Web.Services
{
    public class FeatureService
    {
        private readonly IEFRepository<Feature> _featureRepo;

        public FeatureService(IEFRepository<Feature> featureRepo)
        {
            _featureRepo = featureRepo;
        }

        public async Task<FeatureViewModel> FindAsync(int id)
        {
            var fetchFeature = await _featureRepo.findAsync(id);
        
            if(fetchFeature == null)
            {
                throw new System.Exception();
            }

            return new FeatureViewModel{
                id = fetchFeature.Id,
                Description = fetchFeature.Description
            };
        }

        public async Task<FeatureViewModel> AddAsync(int packetId, string description)
        {
            var createdFeature = await _featureRepo.addAsync(
                    new Feature {
                        Description=description,
                        PacketId = packetId
                        });
            
            return new FeatureViewModel {
                id = createdFeature.Id,
                Description = createdFeature.Description
            };
        }

        public async Task<FeatureViewModel> UpdateAsync(int packetId, FeatureViewModel feature)
        {
            await _featureRepo.updateAsync(
                new Feature {
                    Id = feature.id,
                    Description = feature.Description,
                    PacketId = packetId
                    });

            return feature;
        }

        public async Task DeleteAsync(int packetId, FeatureViewModel feature)
        {
            await _featureRepo.deleteAsync(
                new Feature {
                    Id = feature.id,
                    Description = feature.Description,
                    PacketId = packetId
                });
            
            
        }       
    }

}