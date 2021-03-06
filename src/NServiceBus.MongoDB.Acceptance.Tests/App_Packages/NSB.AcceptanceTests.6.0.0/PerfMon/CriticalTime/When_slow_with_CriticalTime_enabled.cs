﻿namespace NServiceBus.AcceptanceTests.PerfMon.CriticalTime
{
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using AcceptanceTesting;
    using EndpointTemplates;
    using NUnit.Framework;
    using ScenarioDescriptors;

    public class When_slow_with_CriticalTime_enabled : NServiceBusAcceptanceTest
    {
        [Test]
        [Explicit("Since perf counters need to be enabled with powershell")]
        public async Task Should_have_perf_counter_set()
        {
            using (var counter = new PerformanceCounter("NServiceBus", "Critical Time", "SlowWithCriticaltimeEnabled.Endpoint", true))
            {
                using (new Timer(state => CheckPerfCounter(counter), null, 0, 100))
                {
                    await Scenario.Define<Context>()
                        .WithEndpoint<Endpoint>(b => b.When((session, c) => session.SendLocal(new MyMessage())))
                        .Done(c => c.WasCalled)
                        .Repeat(r => r.For(Transports.Default))
                        .Should(c => Assert.True(c.WasCalled, "The message handler should be called"))
                        .Run();
                }
            }
            Assert.Greater(counterValue, 2);
        }

        void CheckPerfCounter(PerformanceCounter counter)
        {
            float rawValue = counter.RawValue;
            if (rawValue > 0)
            {
                counterValue = rawValue;
            }
        }

        float counterValue;

        public class Context : ScenarioContext
        {
            public bool WasCalled { get; set; }
        }

        public class Endpoint : EndpointConfigurationBuilder
        {
            public Endpoint()
            {
                EndpointSetup<DefaultServer>(builder => builder.EnableCriticalTimePerformanceCounter());
            }
        }

        public class MyMessage : IMessage
        {
        }

        public class MyMessageHandler : IHandleMessages<MyMessage>
        {
            public Context Context { get; set; }

            public async Task Handle(MyMessage message, IMessageHandlerContext context)
            {
                await Task.Delay(2000);
                Context.WasCalled = true;
            }
        }
    }
}