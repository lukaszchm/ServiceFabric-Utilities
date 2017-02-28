using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LCH.SF.Framework.ComponentModel.Actors;
using LCH.SF.PoC.IoTSensors.Common.ActorInterfaces;

namespace LCH.SF.PoC.IoTSensors.Actors.Actors
{
    public class DeviceSensor : IoCEnabledActorBase, IDeviceSensor
    {
        /// <summary>
        /// Initializes a new instance of <see cref="T:Microsoft.ServiceFabric.Actors.Runtime.Actor" />
        /// </summary>
        /// <param name="constructorContext"></param>
        public DeviceSensor(IActorConstructorContext constructorContext) : base(constructorContext)
        {
        }

        #region Implementation of IDeviceSensor

        /// <summary>
        /// Sends sensor data from the device to the actor.
        /// </summary>
        /// <param name="sensorData">Collection of key-value pairs representing values from named sensors.</param>
        /// <returns><see cref="Task"/></returns>
        public Task SubmitSensorData(IEnumerable<KeyValuePair<string, double>> sensorData)
        {
            if (sensorData == null) throw new ArgumentNullException(nameof(sensorData));
            throw new System.NotImplementedException();
        }

        #endregion
    }
}