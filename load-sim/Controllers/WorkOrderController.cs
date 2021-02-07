using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace load_sim.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkOrderController : ControllerBase
    {
        private readonly ILogger<WorkOrderController> _logger;

        public WorkOrderController(ILogger<WorkOrderController> logger)
        {
            _logger = logger;
        }

        [HttpGet("cpu-intense")]
        public IEnumerable<long> CpuIntensive()
        {
            var rng = new Random();
            var l = new List<long>();
            for(long i = 0; i < 1000_000_000; i++)
                l.Add(rng.Next());

            return l;
        }
    }
}