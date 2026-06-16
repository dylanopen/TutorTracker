namespace TutorTrackerModel;

public static class UnixTime
{
    public static long ToUnixTime(DateTime dateTime)
    {
        return (long)((dateTime - DateTime.UnixEpoch).TotalSeconds);
    }

    public static DateTime FromUnixTime(long unixTime)
    {
        return DateTime.UnixEpoch.AddSeconds(unixTime);
    }
}
