﻿using System;
using System.Linq;
using HowShop.Core.Domain;
using HowShop.Core.Infra;
using NUnit.Framework;
using Shouldly;
using SolidR.TestFx;

namespace HowTo.IntegratedTests.HowTo
{
    /// <summary>
    /// How? Set property as virtual
    /// </summary>
    [TestFixture]
    public class PrivateSetterTest : IntegratedTest
    {
        [Test]
        [Ignore("TODO: User another properties")]
        public void Should_load_private_setter_property()
        {
            using (var db = new HowShopContext())
            {
                db.Users.Add(new User("John"));
                db.Users.Add(new User("Paul"));
                db.SaveChanges();
            }

            using (var db = new HowShopContext())
            {
                var result = db.Users.ToList();

                result[0].Name.ShouldBe("John");
                result[1].Name.ShouldBe("Paul");
            }
        }
    }
}
