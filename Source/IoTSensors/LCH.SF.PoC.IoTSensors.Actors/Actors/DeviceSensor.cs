using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LCH.SF.PoC.IoTSensors.Common.ActorInterfaces;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.PoC.IoTSensors.Actors.Actors
{
    public class DeviceSensor : Actor, IDeviceSensor
    {
        /// <summary>
        /// Initializes a new instance of <see cref="T:Microsoft.ServiceFabric.Actors.Runtime.Actor" />
        /// </summary>
        /// <param name="actorService">
        /// The <see cref="T:Microsoft.ServiceFabric.Actors.Runtime.ActorService" /> that will host this actor instance.
        /// </param>
        /// <param name="actorId">
        /// The <see cref="T:Microsoft.ServiceFabric.Actors.ActorId" /> for this actor instance.
        /// </param>
        public DeviceSensor(ActorService actorService, ActorId actorId) : base(actorService, actorId)
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
            throw new System.NotImplementedException();
        }

        #endregion
    }
}