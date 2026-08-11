using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}