using Company.Data.Interfaces;

namespace Company.Data.Entities;

public class EmployeeTitle : IReferenceEntity
{
    public int EmployeeId { get; set; }
    public int TitleId { get; set; }
    public Employee Employee { get; set; }
    public Title Title { get; set; }
}
