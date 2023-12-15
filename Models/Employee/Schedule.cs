using System.Runtime.Serialization;

namespace PositronAPI.Models.Employee
{
    public class Schedule
    {
        [DataMember(Name = "EmployeeId")]
        public long EmployeeId { get; set; }

        [DataMember(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [DataMember(Name = "EndDate")]
        public DateTime EndDate { get; set; }
    }
}
