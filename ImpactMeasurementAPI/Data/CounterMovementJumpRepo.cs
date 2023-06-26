using ImpactMeasurementAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ImpactMeasurementAPI.Data
{
    public class CounterMovementJumpRepo : ICounterMovementJumpRepo
    {
        private readonly AppDbContext _context;

        public CounterMovementJumpRepo(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CounterMovementJump> GetAllCounterMovementJumps()
        {
            return _context.CounterMovementJump
                .ToList();
        }
    }
}
