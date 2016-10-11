using System;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;
using SolidR.Domain;

namespace HowShop.Core.Domain
{
    public class Store : Entity
    {
        public string Name { get; private set; }

        [NotMapped]
        public LocalTime OpenAt
        {
            get { return LocalTime.FromTicksSinceMidnight(OpenAtBuddy.Ticks); }
            private set { OpenAtBuddy = TimeSpan.FromTicks(value.TickOfDay); }
        }

        //[NotMapped]
        //public LocalTime CloseAt
        //{
        //    get { return LocalTime.FromTicksSinceMidnight(CloseAtBuddy.Ticks); }
        //    private set { CloseAtBuddy = TimeSpan.FromTicks(CloseAt.TickOfDay); }
        //}

        protected TimeSpan OpenAtBuddy { get; private set; }
        protected TimeSpan CloseAtBuddy { get; private set; }

        private Store()
        {
        }

        public Store(string name)
        {
            Name = name;
        }

        public Store(string name, LocalTime openAt, LocalTime closeAt) : this(name)
        {
            OpenAt = openAt;
            //OpenAt = TimeSpan.FromTicks(openAt.TickOfDay);
            //OpenAtNoda = openAt;
            //CloseAt = closeAt;
        }
    }
}