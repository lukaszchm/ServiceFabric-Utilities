using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LCH.SF.PoC.IoTSensors.Common.ActorInterfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LCH.SF.PoC.IoTSensors.IntegrationTests
{
    [TestClass]
    public class DeviceActorCreationTests
    {
        [TestMethod]
        public async Task actor_instance_is_created()
        {
            var deviceSensor = ActorProxy.Create<IDeviceSensor>(ActorId.CreateRandom(),
                new Uri("fabric:/LCH.SF.PoC/DeviceSensorActorService"));
            await deviceSensor.SubmitSensorData(new []{new KeyValuePair<string, double>("Sensor1", 123.4), });
        }
    }
}
