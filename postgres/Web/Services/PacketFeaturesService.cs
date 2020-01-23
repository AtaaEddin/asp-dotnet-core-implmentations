using System.Linq;
using System;
using System.Threading.Tasks;
using Postgres.Data;
using Postgres.Web.ViewModels;
using System.Collections.Generic;

namespace Postgres.Web.Services
{
    public class PacketFeaturesService
    {
        private readonly PacketRepository _repo;

        public PacketFeaturesService(PacketRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<PacketFeatureViewModel>> GetAllPacketsWithFeaturesAsync()
        {
            var fetchedPacketList = await _repo.findAllWithFeaturesAsync();

            // handle it properly
            if(!fetchedPacketList.Any())
            {
                throw new Exception();
            }

            List<PacketFeatureViewModel> returnedPacketFeatures = new List<PacketFeatureViewModel>();
                fetchedPacketList.ForEach(p => {
                    returnedPacketFeatures.Add(
                        new PacketFeatureViewModel {
                            Id = p.Id,
                            Name = p.Name,
                            ImgUri = p.ImgUrl,
                            Features = p.Features.Select(f => new FeatureViewModel(){
                                id = f.Id,
                                Description = f.Description
                            }).ToList()
                        }
                    );

                });               

            return returnedPacketFeatures;

        }

        public async Task<PacketFeatureViewModel> GetPacketWithFeaturesAsync(int id)
        {
            var fetchedPacketFeatures = await _repo.findWithFeaturesAsync(id);

            // handle it properly
            if(fetchedPacketFeatures == null)
            {
                throw new Exception() ; 
            }

            return new PacketFeatureViewModel {
                Id = fetchedPacketFeatures.Id,
                Name = fetchedPacketFeatures.Name,
                ImgUri = fetchedPacketFeatures.ImgUrl,
                Features = fetchedPacketFeatures.Features.Select(f => new FeatureViewModel(){
                    Description = f.Description,
                    id = f.Id
                }).ToList(),
            };
        }

    }
}