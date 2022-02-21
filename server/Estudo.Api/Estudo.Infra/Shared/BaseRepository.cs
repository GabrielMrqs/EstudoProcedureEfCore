using Estudo.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Estudo.Infra.Shared
{
    public class BaseRepository<T> where T : Entity
    {
        private readonly Context _context;
        private readonly DbSet<T> _registers;

        public BaseRepository(Context context)
        {
            _context = context;
            _registers = _context.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _registers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task EditAsync(T entity)
        {
            _registers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _registers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid entityId)
        {
            return await _registers.SingleOrDefaultAsync(x => x.Id == entityId);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _registers.ToListAsync();
        }

        public async virtual Task<T> ExecuteReaderAsync(Func<DbDataReader, T> mapEntities, string exec, params object[] parameters)
        {
            using var conn = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand(exec, conn);
            conn.Open();
            command.Parameters.AddRange(parameters);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                using var reader = command.ExecuteReaderAsync();
                return mapEntities(await reader);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
