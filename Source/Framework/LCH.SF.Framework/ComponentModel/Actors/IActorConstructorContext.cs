using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.Framework.ComponentModel.Actors
{
    /// <summary>
    /// Exposes methods of a container of values required for an actor constructor.
    /// </summary>
    public interface IActorConstructorContext
    {
        /// <summary>
        /// This method should be called by a constructor of an Actor.
        /// </summary>
        /// <param name="stateManager">Actor state manager.</param>
        void RegisterActorInstance(IActorStateManager stateManager);

        /// <summary>
        /// Gets an instance of <see cref="ActorService"/> hosting current actor instance.
        /// </summary>
        ActorService ActorService { get; }

        /// <summary>
        /// Gets <see cref="ActorId"/> of the actor.
        /// </summary>
        ActorId ActorId { get; }
    }
}