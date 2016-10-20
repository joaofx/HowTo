using System;
using HowShop.Core.Commands;
using NodaMoney;
using SolidR.Core.Domain;

namespace HowShop.Core.Domain
{
    public class User : Entity, ISoftDeletable
    {
        public string Name { get; private set; }
        public bool IsDeleted { get; set; }
        public string Language { get; private set; }
        public int TimeZone { get; private set; }
        public string Culture { get; private set; }

        public Currency Currency
        {
            get { return NodaMoney.Currency.FromCode(CurrencyBuddy); }
            private set { CurrencyBuddy = value.Code; }
        }

        protected string CurrencyBuddy { get; set; }

        private User()
        {
        }

        public User(string name)
        {
            Name = name;
        }

        public void ChangeSettings(UserSettingsEdit.Command command)
        {
            Language = command.Language;
            TimeZone = Convert.ToInt32(command.TimeZone);
            Culture = command.Culture;
            Currency = command.Currency;
        }
    }
}