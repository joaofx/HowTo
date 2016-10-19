using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace HowShop.Core.Commands
{
    public class UserSettingsEdit
    {
        public class Command : IRequest
        {
            public long UserId { get; set; }

            public string Language { get; set; }

            public string TimeZone { get; set; }

            public string Culture { get; set; }

            public Dictionary<string, string> Languages => new Dictionary<string, string>()
            {
                { "en_US", "English U.S." },
                { "en_GB", "English U.K." },
                { "pt_BR", "Portuguese Brazilian" },
            };

            public Dictionary<string, string> TimeZones => TimeZoneInfo.GetSystemTimeZones().ToDictionary(x => x.Id, x => $"{x.BaseUtcOffset} - {x.DisplayName}");

            public Dictionary<string, string> Cultures => new Dictionary<string, string>()
            {
                { "en-US", "English (United States)" },
                { "en-GB", "English (United Kingdom)" },
                { "pt-BR", "Portuguese (Brazil)" },
            };
        }
    }
}