using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitApi9K.DAL;

namespace UnitApi9K.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private UnitManagementDbContext _context;
        public TrainingRepository(UnitManagementDbContext context)
        {
            _context = context;
        }
    }
}