using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.Framework.ComponentModel.Actors
{
    /// <summary>
    /// Exposes methods to register actor creation context.
    /// </summary>
    public interface IActorCreationContext
    {
        /// <summary>
        /// Stores <see cref="ActorService"/> and <see cref="ActorId"/> required for actor constructor.
        /// </summary>
        /// <param name="actorService">Instance of <see cref="ActorService"/> hosting an actor.</param>
        /// <param name="actorId"><see cref="ActorId"/> of an actor.</param>
        void RegisterServiceAndActorId(ActorService actorService, ActorId actorId);
    }
}