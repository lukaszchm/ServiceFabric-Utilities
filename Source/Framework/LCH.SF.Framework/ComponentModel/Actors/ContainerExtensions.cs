using DryIoc;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.Framework.ComponentModel.Actors
{
    public static class ContainerExtensions
    {
        public static IContainer WithActorFactories(this IContainer container)
        {
            container.RegisterMany<ActorActivationContext>(
                Reuse.InResolutionScope,
                serviceTypeCondition: type=>type.IsInterface);

            container.Register(typeof(IActorInstanceFactory<>), typeof(ActorInstanceFactory<>), 
                Reuse.InResolutionScope);

            return container;
        }

        public static TActor ActorFactory<TActor>(this IResolver container, ActorService actorService, ActorId actorId)
            where TActor : IoCEnabledActorBase
        {
            var factory = container.Resolve<IActorInstanceFactory<TActor>>();
            factory.RegisterServiceAndActorId(actorService, actorId);
            return factory.CreateActor();
        }
    }
}