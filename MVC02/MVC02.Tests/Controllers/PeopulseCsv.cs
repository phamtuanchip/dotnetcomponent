using System;

namespace MVC02.Tests.Controllers
{
    public class PeopulseCsv 
    {
        private string _employeeId;
        private string _lastName;
        private string _firstName;
        private string _position;
        private decimal _hourlyRate;
        private string _shortnameOfSite;
        private string _analyticalCodeOfSite;
        private string _staffProvider;
        private string _labelOfAgency;
        private string _codeOfAgency;
        private DateTime _missionStartDate;
        private string _hourlyShift;
        private string _employeeType;

        public String EmployeeId
        {
            get { return _employeeId; }
        }

        public void SetEmployeeId(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("Employee Id is required!");
            _employeeId = value;
        }

        public void SetLastName(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("LastName is required!");
            _lastName = value;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public void SetFirstName(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("FirstName is required!");
            _firstName = value;
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public void SetEmployeeType(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("EmployeeType is required!");
            switch (value.ToUpper())
            {
                case "E" : case "I" : case "H" : case "S" :
                {
                    _employeeType = value;
                    break;
                }
                default: throw new PeopulseFieldRequiredException("Employee Type should be E,I,H,S!");
            }
           
        }

        public string GetEmployeeType()
        {
            return _employeeType;
        }

        public void SetPosition(string value)
        {
            _position = value;
        }

        public string GetPosition()
        {
            return _position;
        }

        public void SetHourlyRate(decimal value)
        {
            _hourlyRate = value;
        }

        public decimal GetHourlyRate()
        {
            return _hourlyRate;
        }

        public String InvoicingRate { get; set; }

        public void SetShortnameOfSite(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("FirstName is required!");
            _shortnameOfSite = value;
        }

        public string GetShortnameOfSite()
        {
            return _shortnameOfSite;
        }

        public void SetAnalyticalCodeOfSite(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("Analytical Code Of Site is required!");
            _analyticalCodeOfSite = value;
        }

        public string GetAnalyticalCodeOfSite()
        {
            return _analyticalCodeOfSite;
        }

        public void SetStaffProvider(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("Staff Provider is required!");
            _staffProvider = value;
        }

        public string GetStaffProvider()
        {
            return _staffProvider;
        }

        public void SetLabelOfAgency(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("Label Of Agency is required!");
            _labelOfAgency = value;
        }

        public string GetLabelOfAgency()
        {
            return _labelOfAgency;
        }

        public void SetCodeOfAgency(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("Code Of Agency is required!");
            _codeOfAgency = value;
        }

        public string GetCodeOfAgency()
        {
            return _codeOfAgency;
        }

        public void SetMissionStartDate(DateTime value)
        {
            _missionStartDate = value;
        }

        public DateTime GetMissionStartDate()
        {
            return _missionStartDate;
        }

        public DateTime? MissionEndDate { get; set; }

        public void SetHourlyShift(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) throw new PeopulseFieldRequiredException("Hourly Shift is required!");
            _hourlyShift = value;
        }

        public string GetHourlyShift()
        {
            return _hourlyShift;
        }

        public String Currency { get; set; }

        public PeopulseCsv(string[] line)
        {
          int i = 0;  
            {
                SetEmployeeId(line[i++]);
                SetLastName(line[i++]);
                SetFirstName(line[i++]);
                DateOfBirth = InterfacePeopulseUtility.ConvertDateNullAble(line[i++]);
                Gender = InterfacePeopulseUtility.ReadGender(line[i++]);
                SetEmployeeType(line[i++]);
                SetPosition(line[i++]);
                SetHourlyRate(InterfacePeopulseUtility.ConvertDataNumeric(line[i++]));
                InvoicingRate = line[i++];
                SetShortnameOfSite(line[i++]);
                SetAnalyticalCodeOfSite(line[i++]);
                SetStaffProvider(line[i++]);
                SetLabelOfAgency(line[i++]);
                SetCodeOfAgency(line[i++]);
                SetMissionStartDate(InterfacePeopulseUtility.ConvertDate(line[i++]));
                MissionEndDate = InterfacePeopulseUtility.ConvertDateNullAble(line[i++]);
                SetHourlyShift(line[i++]);
                Currency = line[i++];
            }
        }
        
        public PeopulseDataException Validate()
        {
            if (String.IsNullOrEmpty(GetShortnameOfSite())) return new PeopulseSiteNullException("Peopulse Data Exception site is required!");
            if (String.IsNullOrEmpty(GetStaffProvider()) && String.IsNullOrEmpty(GetLabelOfAgency()) && String.IsNullOrEmpty(GetCodeOfAgency()))
                return new PeopulseAgencyNullException("Peopulse Data Exception Agency is required!");
            if (String.IsNullOrEmpty(EmployeeId) && String.IsNullOrEmpty(GetFirstName()) && String.IsNullOrEmpty(GetLastName()))
                return new PeopulseEmployeeNullException("Peopulse Data Exception Employee is required!");
            return null;
        }
    }
}
