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
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                var container = new Container();
                ActorRuntime.RegisterActorAsync<DeviceSensor>((context, typeInformation) =>
                    new ActorService(context, typeInformation, (service, id) =>
                    {
                        var factory = container.Resolve<IActorInstanceFactory<DeviceSensor>>();
                        factory.RegisterServiceAndActorId(service, id);
                        return factory.CreateActor();
                    })).GetAwaiter().GetResult();
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
