namespace alpha_api.Core.Enums
{

    public enum UnitState
    {
        IDLE,
        NORMAL_OPERATION,
        SUSPENDED,
        FAULT,
        DISENGAGED
    }

    public enum EntryMeasure
    {
        IGNORE,
        FOLLOW_UP,
        RESTORE,
    }

    public enum EntryTag
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
