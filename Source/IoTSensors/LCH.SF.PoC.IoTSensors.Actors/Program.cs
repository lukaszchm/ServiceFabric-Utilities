using System;
using System.Threading;
using DryIoc;
using LCH.SF.Framework.ComponentModel.Actors;
using LCH.SF.PoC.IoTSensors.Actors.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.PoC.IoTSensors.Actors
{
    internal static class Program
    {
        private static void Main()
        {
            try
            {
                var container = new Container()
                    .WithActorFactories();

                container.RegisterMany(new [] { typeof(Program).Assembly}, 
                    type=>type.IsAssignableTo(typeof(IoCEnabledActorBase)));

                ActorRuntime.RegisterActorAsync<DeviceSensor>((context, typeInformation) =>
                    new ActorService(context, typeInformation, 
                        container.ActorFactory<DeviceSensor>
                    )).GetAwaiter().GetResult();
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
