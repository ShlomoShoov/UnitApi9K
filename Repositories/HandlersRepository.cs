using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UnitApi9K.DAL;

namespace UnitApi9K.Repositories
{
    public class HandlersRepository : IHandlersRepository
    {
        private UnitManagementDbContext _context;
        public HandlersRepository(UnitManagementDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteHandlerAsync(int id)
        {
            bool deleted = await _context.Handlers.Where(h=> h.Id == id).ExecuteDeleteAsync() > 0;
            return deleted;
        }
    }
}