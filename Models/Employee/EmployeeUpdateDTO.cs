using System.Runtime.Serialization;

namespace PositronAPI.Models.Employee;

public class EmployeeUpdateDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public Role Role { get; set; }
    public double Wage { get; set; }
    public long DepartmentId { get; set; }
}