using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitApi9K.DAL;

namespace UnitApi9K.Repositories
{
    public class DogsRepository : IDogsRepository
    {
        private UnitManagementDbContext _context;
        public DogsRepository(UnitManagementDbContext context)
        {
            _context = context;
        }

    }
}