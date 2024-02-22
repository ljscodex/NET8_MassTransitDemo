using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit.Futures.Contracts;

namespace NET8_MassTransit_Demo.Contracts
{
    public class MasstransitContracts
    {
        public record Person ()
        {
            public string Name { get; init; }
            public int Age {get; init;}
        };
    }
}