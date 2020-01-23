using System.Threading.Tasks;
using Postgres.Business.Entites.PacketAggregate;
using Postgres.Business.Interfaces;
using Postgres.Data;
using Postgres.Web.ViewModels;

namespace Postgres.Web.Services
{
    public class PacketService
    {
        private readonly PacketRepository _PacketRepository;
        public PacketService(PacketRepository PacketRepository)
        {
            _PacketRepository = PacketRepository;
        }
        public async Task<PacketViewModel> AddPacketAsync(string name,string imgUri)
        {
            // add packet to context
            var createdPacket = await _PacketRepository.addAsync(new Packet {Name=name,ImgUrl=imgUri});
            
            if(createdPacket != null)
            {
                return null;
            }

            return new PacketViewModel {Id=createdPacket.Id, Name=name, ImgUri=imgUri};
        }

        public async Task DeleteAsync(int id)
        {
            var fetchedPacket = await _PacketRepository.findAsync(id);
            await _PacketRepository.deleteAsync(fetchedPacket);

        }

        public async Task<PacketViewModel> GetAsync(int id)
        {
            var fetchedPacket = await _PacketRepository.findAsync(id);
            return new PacketViewModel {
                Id = fetchedPacket.Id,
                Name = fetchedPacket.Name,
                ImgUri = fetchedPacket.ImgUrl
            };
        }

        public async Task<PacketViewModel> UpdateAsync(PacketViewModel packetViewModel)
        {
            var newPacket = new Packet {
                Id = packetViewModel.Id,
                Name = packetViewModel.Name,
                ImgUrl = packetViewModel.ImgUri
            };
            await _PacketRepository.updateAsync(newPacket);

            return packetViewModel;

        }
    }
}