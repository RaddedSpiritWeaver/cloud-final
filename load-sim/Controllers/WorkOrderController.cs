using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
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
            for (long i = 0; i < 1000_000_000; i++)
                l.Add(rng.Next());

            return l;
        }
        [HttpGet("{order}/{num}")]
        public ActionResult test(int order, int num)
        {
            return Ok(Order(order, num));
        }
        [HttpGet("testMemory/{order}")]

        public ActionResult testMemory(long order)
        {
            List<Person> people = new List<Person>();
            for (long i = 0; i < Math.Pow(10,order); i++)
            {
                Person p = new Person()
                {
                    FirstName =i%2==0? "armin":"erfan",
                    LastName = i % 2 == 0 ? "afzali" : "noohi",
                    Age = i % 2 == 0 ? 23 : 22,
                    Id = i,
                };
                people.Add(p);
            }
            return Ok("done");

        }
        private long Order(int order, int num)
        {
            long sum = 0;
            if (order == 0 || num == 0)
                return 1;
            for (int i = 0; i < order; i++)
            {
                sum += Order(order, num - 1) + 1;
            }
            return sum;
        }


    }
    public class Person{
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

    }

}