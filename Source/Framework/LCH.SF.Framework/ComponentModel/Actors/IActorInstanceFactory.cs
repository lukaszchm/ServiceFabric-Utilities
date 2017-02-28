using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.Framework.ComponentModel.Actors
{
    /// <summary>
    /// Exposes methods of a container of values required for creation of actor instance.
    /// </summary>
    public interface IActorInstanceFactory<out TActor>
        where TActor : ActorBase
    {
        /// <summary>
        /// Stores <see cref="ActorService"/> and <see cref="ActorId"/> required for actor constructor.
        /// </summary>
        /// <param name="actorService">Instance of <see cref="ActorService"/> hosting an actor.</param>
        /// <param name="actorId"><see cref="ActorId"/> of an actor.</param>
        void RegisterServiceAndActorId(ActorService actorService, ActorId actorId);

        /// <summary>
        /// Creates new instance of <see cref="TActor"/>.
        /// </summary>
        /// <returns>New instance of <see cref="TActor"/></returns>
        TActor CreateActor();
    }
}