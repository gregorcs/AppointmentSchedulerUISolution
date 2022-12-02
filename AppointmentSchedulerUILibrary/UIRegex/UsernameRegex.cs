namespace AppointmentSchedulerUILibrary.UIRegex
{
    public class UsernameRegex
    {
        /* 
         * - 3 - 32 characters
         * - any letter (lower- and uppercase) or number
         * - no special characters allowed except for - & _
        */
        public const string Pattern = "[a-zA-Z][a-zA-Z0-9-_]{2,31}";
    }
}
