using System;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;
using SolidR.Core.Domain;

namespace HowShop.Core.Domain
{
    public class Store : Entity
    {
        public string Name { get; private set; }

        public LocalTime OpenAt
        {
            get { return LocalTime.FromTicksSinceMidnight(OpenAtValue.Ticks); }
            private set { OpenAtValue = TimeSpan.FromTicks(value.TickOfDay); }
        }

        public LocalTime CloseAt
        {
            get { return LocalTime.FromTicksSinceMidnight(CloseAtValue.Ticks); }
            private set { CloseAtValue = TimeSpan.FromTicks(CloseAt.TickOfDay); }
        }

        public TimeSpan OpenAtValue { get; protected set; }
        public TimeSpan CloseAtValue { get; protected set; }

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
            CloseAt = closeAt;
        }
    }
}