using System.Runtime.Serialization;

namespace PositronAPI.Models.Employee;

public class EmployeeImportDTO
{
    [DataMember(Name = "name")] public string Name { get; set; }

    [DataMember(Name = "surname")] public string Surname { get; set; }

    [DataMember(Name = "role")] public Role Role { get; set; }

    [DataMember(Name = "wage")] public double Wage { get; set; }

    [DataMember(Name = "departmentId")] public long DepartmentId { get; set; }
}