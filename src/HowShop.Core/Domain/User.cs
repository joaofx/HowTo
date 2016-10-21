using System;
using HowShop.Core.Commands;
using HowShop.Core.Concerns;
using NodaMoney;
using SolidR.Core.Domain;

namespace HowShop.Core.Domain
{
    public class User : Entity, ISoftDeletable
    {
        public string Name { get; private set; }
        public bool IsDeleted { get; set; }

        public Language Language
        {
            get { return Language.FromId(LanguageValue); }
            private set { LanguageValue = value.Id; }
        }

        public int TimeZone { get; private set; }
        public string Culture { get; private set; }

        public Currency Currency
        {
            get { return Currency.FromCode(CurrencyValue); }
            private set { CurrencyValue = value.Code; }
        }

        public string CurrencyValue { get; private set; }

        private string LanguageValue { get; set; }

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