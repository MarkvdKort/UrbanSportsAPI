using AutoMapper;
using ImpactMeasurementAPI.Data;
using ImpactMeasurementAPI.DTOs;
using ImpactMeasurementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ImpactMeasurementAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CounterMovementJumpController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICounterMovementJumpRepo _counterMovementJumpRepo;

        public CounterMovementJumpController(ICounterMovementJumpRepo counterMovementJumpRepo, IMapper mapper)
        {
            _counterMovementJumpRepo = counterMovementJumpRepo;
            _mapper = mapper;
        }
        [HttpGet("countermovementjump/all", Name = "GetCounterMovementJumps")]
        public ActionResult<IEnumerable<ReadCounterMovementJump>> getCounterMovementJump()
        {
            var counterMovementJumps = _counterMovementJumpRepo.GetAllCounterMovementJumps();

            if(counterMovementJumps != null && counterMovementJumps.Count() != 0)
            {
                return Ok(_mapper.Map<IEnumerable<ReadCounterMovementJump>>(counterMovementJumps));
            }
            return NotFound();
        }

    }
}
