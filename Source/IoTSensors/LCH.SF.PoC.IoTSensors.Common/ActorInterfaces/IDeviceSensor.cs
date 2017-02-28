using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace LCH.SF.PoC.IoTSensors.Common.ActorInterfaces
{
    /// <summary>
    /// Exposes methods for an actor representing sensors on a single devices.
    /// </summary>
    public interface IDeviceSensor : IActor
    {
        /// <summary>
        /// Sends sensor data from the device to the actor.
        /// </summary>
        /// <param name="sensorData">Collection of key-value pairs representing values from named sensors.</param>
        /// <returns><see cref="Task"/></returns>
        Task SubmitSensorData(IEnumerable<KeyValuePair<string, double>> sensorData);
    }
}
