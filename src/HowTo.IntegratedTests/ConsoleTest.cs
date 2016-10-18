using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HowShop.Core.Commands;
using HowShop.Core.Domain;
using NUnit.Framework;
using Shouldly;

namespace HowTo.IntegratedTests
{
    [TestFixture]
    public class ConsoleTest
    {
        private List<Expression<Func<ConsoleTest, object>>> _expressions = new List<Expression<Func<ConsoleTest, object>>>();

        [Test]
        public void Should_save()
        {
            For(_ => _.WithName());
        }

        private string WithName()
        {
            return "Joao";
        }

        private void For(Expression<Func<ConsoleTest, object>> func)
        {
            _expressions.Add(func);
        }
    }
}
