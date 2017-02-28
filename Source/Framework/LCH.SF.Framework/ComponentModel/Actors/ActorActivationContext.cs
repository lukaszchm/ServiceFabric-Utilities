using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.Framework.ComponentModel.Actors
{
    /// <summary>
    /// A container class for values required for actor instance creation.
    /// </summary>
    public class ActorActivationContext : IActorConstructorContext, IActorCreationContext
    {
        #region Implementation of IActorConstructorContext

        /// <summary>
        /// This method should be called by a constructor of an Actor.
        /// </summary>
        /// <param name="stateManager">Actor state manager.</param>
        public void RegisterActorInstance(IActorStateManager stateManager)
        {
            if (stateManager == null) throw new ArgumentNullException(nameof(stateManager));

            if (ActorId == null || ActorService == null)
            {
                throw new InvalidOperationException("Actor creation context was not registered before actor creation.");
            }
        }

        /// <summary>
        /// Gets an instance of <see cref="IActorConstructorContext.ActorService"/> hosting current actor instance.
        /// </summary>
        public ActorService ActorService { get; private set; }

        /// <summary>
        /// Gets <see cref="IActorConstructorContext.ActorId"/> of the actor.
        /// </summary>
        public ActorId ActorId { get; private set; }

        #endregion

        #region Implementation of IActorCreationContext

        /// <summary>
        /// Stores <see cref="Microsoft.ServiceFabric.Actors.Runtime.ActorService"/> and <see cref="Microsoft.ServiceFabric.Actors.ActorId"/> required for actor constructor.
        /// </summary>
        /// <param name="actorService">Instance of <see cref="Microsoft.ServiceFabric.Actors.Runtime.ActorService"/> hosting an actor.</param>
        /// <param name="actorId"><see cref="Microsoft.ServiceFabric.Actors.ActorId"/> of an actor.</param>
        public void RegisterServiceAndActorId(ActorService actorService, ActorId actorId)
        {
            if (actorService == null) throw new ArgumentNullException(nameof(actorService));
            if (actorId == null) throw new ArgumentNullException(nameof(actorId));
            ActorService = actorService;
            ActorId = actorId;
        }

        #endregion
    }
}