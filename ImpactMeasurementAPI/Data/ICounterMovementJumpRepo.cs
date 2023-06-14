using ImpactMeasurementAPI.Models;
using System.Collections.Generic;

namespace ImpactMeasurementAPI.Data
{
    public interface ICounterMovementJumpRepo
    {
        IEnumerable<CounterMovementJump> GetAllCounterMovementJumps();
    }
}
