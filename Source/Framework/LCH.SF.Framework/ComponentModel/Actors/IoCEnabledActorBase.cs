using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;

namespace LCH.SF.Framework.ComponentModel.Actors
{
    public class IoCEnabledActorBase : Actor
    {
        /// <summary>
        /// Initializes a new instance of <see cref="T:Microsoft.ServiceFabric.Actors.Runtime.Actor" />
        /// </summary>
        /// <param name="constructorContext"></param>
        public IoCEnabledActorBase(IActorConstructorContext constructorContext) 
            : base(constructorContext.ActorService, constructorContext.ActorId)
        {
            constructorContext.RegisterActorInstance(StateManager);
        }
    }
}