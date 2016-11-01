using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HowShop.Core.Concerns;

namespace HowShop.Core.Domain
{
    public enum Profile
    {
        Customer = 0,
        Admin = 1,
        BackOffice = 2
    }

    public static class ProfileEx
    {
        public static IEnumerable<Feature> GetFeatures(this Profile profile)
        {
            if (profile == Profile.Admin)
            {
                return Enum.GetValues(typeof (Feature)).Cast<Feature>();
            }

            if (profile == Profile.BackOffice)
            {
                return new[] { Feature.ManageProducts };
            }

            return new List<Feature>();
        }

        public static bool DoNotHaveAccessTo(this Profile profile, Feature feature)
        {
            var features = profile.GetFeatures();
            return features.Contains(feature) == false;
        }
    }
}