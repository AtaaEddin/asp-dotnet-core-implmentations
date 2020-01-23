using System.Collections.Generic;
using System.Threading.Tasks;
using Postgres.Business.Entites.PacketAggregate;
using Microsoft.EntityFrameworkCore;

namespace Postgres.Data
{
    public class PacketRepository : EFRepository<Packet>
    {
        private readonly PacketContext _context;

        public PacketRepository (PacketContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Packet>> findAllWithFeaturesAsync()
        {
            return await _context.Packets
                    .Include(p => p.Features)
                    .ToListAsync();
        }

        public async Task<Packet> findWithFeaturesAsync(int id)
        {
            return await _context.Packets
                    .Include(p => p.Features)
                    .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}