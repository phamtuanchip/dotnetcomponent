using System;

namespace MVC02.Tests.Controllers
{
    public class PeopulseDataException : Exception
    {
        public PeopulseDataException(String msg) : base(msg) { }
    }
    public class PeopulseFieldRequiredException : PeopulseDataException
    {
        public PeopulseFieldRequiredException(String msg) : base(msg) { }
    }
    public class PeopulseDataFormatException : PeopulseDataException
    {
        public PeopulseDataFormatException(String msg) : base(msg) { }
    }
    public class PeopulseSiteNullException : PeopulseDataException
    {
        public PeopulseSiteNullException(String msg) : base(msg) { }
    }
    public class PeopulseAgencyNullException : PeopulseDataException
    {
        public PeopulseAgencyNullException(String msg) : base(msg) { }
    }
    public class PeopulseEmployeeNullException : PeopulseDataException
    {
        public PeopulseEmployeeNullException(String msg) : base(msg) { }
    }
    public class PeopulseAgencyNotDistinctException : PeopulseDataException
    {
        public PeopulseAgencyNotDistinctException(String msg) : base(msg) { }
    }
    public class PeopulseMissionNotFoundException: PeopulseDataException
    {
        public PeopulseMissionNotFoundException(String msg) : base(msg) { }
    }
    public class PeopulseMissionStartDateException : PeopulseDataException
    {
        public PeopulseMissionStartDateException(String msg) : base(msg) { }
    }
    public class PeopulseEmployeeNotFoundException : PeopulseDataException
    {
        public PeopulseEmployeeNotFoundException(String msg) : base(msg) { }
    }

    public class PeopulseSiteNotFoundException : PeopulseDataException
    {
        public PeopulseSiteNotFoundException(String msg) : base(msg) { }
    }

    public class PeopulseAttendanceReasonNotFoundException : PeopulseDataException
    {
        public PeopulseAttendanceReasonNotFoundException(String msg) : base(msg) { }
    }

    public class PeopulseAttendanceDataValidateException : PeopulseDataException
    {
        public PeopulseAttendanceDataValidateException(String msg) : base(msg) { }
    }

    public class PeopulseMissionAttendanceDataValidateException : PeopulseDataException
    {
        public PeopulseMissionAttendanceDataValidateException(String msg) : base(msg) { }
    }

    public class PeopulseSortedQuantitiesDataValidateException : Exception
    {
        public PeopulseSortedQuantitiesDataValidateException(String msg) : base(msg) { }
    }

    public class PeopulseMissionDateWarningException : PeopulseDataException
    {
        public PeopulseMissionDateWarningException(String msg) : base(msg) { }
    }
    public class PeopulseMissionAdditionalCostException : PeopulseDataException
    {
        public PeopulseMissionAdditionalCostException(String msg) : base(msg) { }
    }
}
