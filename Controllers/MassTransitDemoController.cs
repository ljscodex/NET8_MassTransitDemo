using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using static NET8_MassTransit_Demo.Contracts.MasstransitContracts;

namespace NET8_MassTransit_Demo.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class MassTransitDemoController : ControllerBase
    {
        private readonly IBus _masstransitBus;

        public MassTransitDemoController( IBus masstransitBus)
        {
            _masstransitBus = masstransitBus;
        }

        [HttpGet]
        public ActionResult<Person> Get([FromQuery]Person p)
        {
            _masstransitBus.Publish(p);
            return p;
        }
    }
}