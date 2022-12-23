using Company.Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Company.Data.Entities;

public class Department : IEntity
{
    public int Id { get ; set; }
    [MaxLength(50), Required]
    public string Name { get; set; }
    public int BusinessId { get; set; }
    public Business Business { get; set; }

}
