using Company.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class Employee : IEntity
{
    public int Id { get;set ; }
    [MaxLength(50), Required]
    public string FirstName { get;set; }
    [MaxLength(50), Required]
    public string LastName { get;set; }
    public double Salary { get; set; }
    public bool UnionMember { get; set; }
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
    public virtual ICollection<Title> Title { get; set; }
}

