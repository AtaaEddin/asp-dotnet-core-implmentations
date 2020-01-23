using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Postgres.Business.Entites;
using Postgres.Business.Interfaces;

namespace Postgres.Data
{
    public class EFRepository<T> : IEFRepository<T> where T : BaseEntity,IAggregateRoot
    {
        private readonly PacketContext _context;
        public EFRepository(PacketContext context)
        {
            _context = context;
        }
        public async Task<T> addAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();            
            return entity;
        }

        public async Task deleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> findAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> findAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task updateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}