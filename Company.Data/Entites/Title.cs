using Company.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class Title : IEntity
{
    public int Id { get; set; }
    [MaxLength(50), Required]
    public string Role { get; set; }
    public virtual ICollection<Employee> Employee { get; set; }
}
