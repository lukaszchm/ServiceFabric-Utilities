using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.Framework.ComponentModel.Actors
{
    public class ActorInstanceFactory<TActor> : IActorInstanceFactory<TActor> 
        where TActor : ActorBase
    {
        private readonly Lazy<TActor> _lazyActor;
        private readonly IActorCreationContext _actorCreationContext;
        public ActorInstanceFactory(Lazy<TActor> lazyActor, IActorCreationContext actorCreationContext)
        {
            _lazyActor = lazyActor;
            _actorCreationContext = actorCreationContext;
        }

        public TActor CreateActor()
        {
            return _lazyActor.Value;
        }

        public void RegisterServiceAndActorId(ActorService actorService, ActorId actorId)
        {
            if (actorService == null) throw new ArgumentNullException(nameof(actorService));
            if (actorId == null) throw new ArgumentNullException(nameof(actorId));
            _actorCreationContext.RegisterServiceAndActorId(actorService, actorId);
        }
    }

   
}