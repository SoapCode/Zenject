using System;
using System.Collections.Generic;
using Zenject;
using NUnit.Framework;
using System.Linq;
using ModestTree;
using Assert=ModestTree.Assert;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestFactoryToMethod0 : TestWithContainer
    {
        [Test]
        public void TestSelf()
        {
            var foo = new Foo();

            Container.BindFactory<Foo, Foo.Factory>().ToMethod((c) => foo);

            AssertValidates();

            Assert.IsEqual(Container.Resolve<Foo.Factory>().Create(), foo);
        }

        [Test]
        public void TestConcrete()
        {
            var foo = new Foo();

            Container.BindFactory<IFoo, IFooFactory>().ToMethod((c) => foo);

            AssertValidates();

            Assert.IsEqual(Container.Resolve<IFooFactory>().Create(), foo);
        }

        interface IFoo
        {
        }

        class IFooFactory : Factory<IFoo>
        {
        }

        class Foo : IFoo
        {
            public class Factory : Factory<Foo>
            {
            }
        }
    }
}
