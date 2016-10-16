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
        public void Should_load_private_setter_property()
        {
            using (var db = new HowShopContext())
            {
                db.Users.Add(new User("John", 20));
                db.Users.Add(new User("Paul", 30));
                db.SaveChanges();
            }

            using (var db = new HowShopContext())
            {
                var result = db.Users.ToList();

                result[0].Name.ShouldBe("John");
                result[0].YearOfBirth.ShouldBe(DateTime.Now.Year - 20);

                result[1].Name.ShouldBe("Paul");
                result[1].YearOfBirth.ShouldBe(DateTime.Now.Year - 30);
            }
        }
    }
}