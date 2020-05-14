using System.Globalization;

namespace Burak.Authorization.Utilities.Constants
{
    public class AppConstants
    {
        public const string SolutionName = "Burak.Authorization";
        public const string DataStorageSection = "DataStorageSection";
        public const string AcceptedLanguageHeaderKey = "Accept-Language";
        public static CultureInfo DefaultCultureInfo = new CultureInfo("en-US");
        public const string AppCenterTokenHeaderKey = "X-API-Token";
        public const string AppCenterNotificationSoundCustomDataKey = "sound";
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 25;
        public const string JWTSecretKey = "This is a secret key, it should not be shared with others!";


        /* Appointment Status */
        public const string AppointmentStatusPending = "Pending";
    }
}