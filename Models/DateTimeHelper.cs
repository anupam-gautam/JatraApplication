namespace JatraApplication.Models
{
    public class DateTimeHelper
    {
        static List<string> nepaliDays = new List<string> { "०", "१", "२", "३", "४", "५", "६", "७", "८", "९", "१०", "११", "१२", "१३", "१४", "१५", "१६", "१७", "१८", "१९", "२०", "२१", "२२", "२३", "२४", "२५", "२६", "२७", "२८", "२९", "३०", "३१", "३२" };
        public static string DTfor(DateTime dt)
        {
            var day = dt.Day;
            var nepaliDateDevnagiri = nepaliDays[day];
            return nepaliDateDevnagiri;
        }
    }
}
