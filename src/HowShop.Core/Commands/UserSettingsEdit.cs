using System;
using System.Collections.Generic;
using System.Linq;
using HowShop.Core.Concerns;
using HowShop.Core.Infra;
using MediatR;
using NodaMoney;

namespace HowShop.Core.Commands
{
    public class UserSettingsEdit
    {
        public class Command : IRequest
        {
            public long UserId { get; set; }

            public Language Language { get; set; }

            public string TimeZone { get; set; }

            public string Culture { get; set; }

            public Currency Currency { get; set; }
            
            public Dictionary<string, string> TimeZones => TimeZoneInfo.GetSystemTimeZones().ToDictionary(x => x.Id, x => $"{x.BaseUtcOffset} - {x.DisplayName}");

            public Dictionary<string, string> Cultures => new Dictionary<string, string>()
            {
                { "en-US", "English (United States)" },
                { "en-GB", "English (United Kingdom)" },
                { "pt-BR", "Portuguese (Brazil)" },
            };
        }

        public class Handler : RequestHandler<Command>
        {
            private readonly HowShopContext _db;

            public Handler(HowShopContext db)
            {
                _db = db;
            }

            protected override void HandleCore(Command message)
            {
                var user = _db.Users.Find(message.UserId);
                user.ChangeSettings(message);
            }
        }
    }
}