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

        public TimeZoneInfo TimeZone
        {
            get { return TimeZoneInfo.FindSystemTimeZoneById(TimeZoneValue); }
            private set { TimeZoneValue = value.Id; }
        }
        
        public Currency Currency
        {
            get { return Currency.FromCode(CurrencyValue); }
            private set { CurrencyValue = value.Code; }
        }

        public Culture Culture
        {
            get { return Culture.FromId(CultureValue); }
            private set { CultureValue = value.Id; }
        }

        public string CurrencyValue { get; private set; }
        public string LanguageValue { get; private set; }
        public string CultureValue { get; private set; }
        public string TimeZoneValue { get; private set; }

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
            TimeZone = command.TimeZone;
            Culture = command.Culture;
            Currency = command.Currency;
        }
    }
}