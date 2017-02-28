using System;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container = DryIoc.Container;

namespace LCH.SF.Framework.Tests
{
    [TestClass]
    public class DryiocTests
    {
        public class Component
        {
            public Component(CreationContext context)
            {
                Parameter = context.Parameter;
            }

            public object Parameter { get; private set; }
        }

        public class Factory
        {
            private readonly CreationContext _context;
            private readonly Lazy<Component> _lazyComponent;
            public Factory(CreationContext context, Lazy<Component> lazyComponent)
            {
                _context = context;
                _lazyComponent = lazyComponent;
            }

            public Component CreateComponent()
            {
                return _lazyComponent.Value;
            }

            public object Parameter
            {
                set { _context.Parameter = value; }
            }
        }

        public class CreationContext
        {
            public object Parameter { get; set; }
        }

        [TestMethod]
        public void test_lazy_resolve_and_resolutionscope_reuse()
        {
            var container = new Container();
            container.Register<Component>(Reuse.InResolutionScope);
            container.Register<CreationContext>(Reuse.InResolutionScope);
            container.Register<Factory>(Reuse.Transient);

            var object1 = new object();
            var factory1 = container.Resolve<Factory>();
            factory1.Parameter = object1;

            var object2 = new object();
            var factory2 = container.Resolve<Factory>();
            factory2.Parameter = object2;


            var component1 = factory1.CreateComponent();
            var component2 = factory2.CreateComponent();

            Assert.AreSame(component1.Parameter, object1);
            Assert.AreNotSame(component1.Parameter, component2.Parameter);
        }
    }
}
