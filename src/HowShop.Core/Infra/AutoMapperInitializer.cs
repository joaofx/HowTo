using AutoMapper;

namespace HowShop.Core.Infra
{
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.AddProfiles(typeof(AutoMapperInitializer));
            });
        }
    }
}
