namespace alpha_api.Core.Enums
{

    public enum State
    {
        IDLE,
        NORMAL_OPERATION,
        SUSPENDED,
        FAULT,
        DISENGAGED
    }

    public enum Measure
    {
        IGNORE,
        FOLLOW_UP,
        RESTORE,
    }

    public enum Tag
    { 
        PERIODIC_INTEGRITY_CHECK,
        MONTHLY_FIELD_TEST,
        DEVIATION_IDENTIFIED,
        TEMP_LOW
    }

    public enum Event
    {
        ROUTINE,
        UPGRADE,
        REPORT,
        ALERT,
        CRITICAL
    }

}
