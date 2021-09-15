using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationSchedulingSystemAPI.Utility
{
    public static class SD
    {
        public const string CompanyTypeSmall = "Small";
        public const string CompanyTypeMedium = "Medium";
        public const string CompanyTypeLarge = "Large";

        public const string MarketDenmark = "Denmark";
        public const string MarketNorway = "Norway";
        public const string MarketSweden = "Sweden";
        public const string MarketFinland = "Finland";

        public static int[] NotificationDaysDenmark = {1, 5, 10, 15, 20};
        public static int[] NotificationDaysNorway = {1, 5, 10, 20};
        public static int[] NotificationDaysSweden = {1, 7, 14, 28};
        public static int[] NotificationDaysFinland = { 1, 5, 10, 15, 20 };
    }
}
