using System.ComponentModel.DataAnnotations;

namespace ImpactMeasurementAPI.Models
{
    public class CounterMovementJump
    {
        [Required] public int Id { get; set; }

        [Required] public decimal Acc_Y { get; set; }
    }
}
