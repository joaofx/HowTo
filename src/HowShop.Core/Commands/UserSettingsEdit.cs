using MediatR;

namespace HowShop.Core.Commands
{
    public class UserSettingsEdit
    {
        public class Command : IRequest
        {
            public long UserId { get; set; }

            // TODO: Timezone, Language, Culture
        }
    }
}