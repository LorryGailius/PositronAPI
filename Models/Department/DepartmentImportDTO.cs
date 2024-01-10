﻿using System.Runtime.Serialization;

namespace PositronAPI.Models.Department;

public class DepartmentImportDTO
{
    [DataMember(Name = "managerId")]
    public long? ManagerId { get; set; }

    [DataMember(Name = "name")]
    public string Name { get; set; }
}