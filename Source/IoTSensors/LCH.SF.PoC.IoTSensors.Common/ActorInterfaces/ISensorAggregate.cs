using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace LCH.SF.PoC.IoTSensors.Common.ActorInterfaces
{
    /// <summary>
    /// Esposes method for actor used to calculate some agregate of a stream of sensor data.
    /// </summary>
    public interface ISensorAggregate : IActor
    {
        /// <summary>
        /// Sends sensor value to the aggregate.
        /// </summary>
        /// <param name="sensorValue">Current sensor value.</param>
        /// <returns><see cref="Task"/></returns>
        Task SubmitSensorValue(double sensorValue);

        /// <summary>
        /// Gets current aggregated value.
        /// </summary>
        /// <returns>Current aggregated value of the sensor.</returns>
        Task<double> GetCurrentAggregatedValue();
    }
}