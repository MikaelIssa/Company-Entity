using Company.Data.Entities;
using Company.Data.Interfaces;
using Microsoft.Extensions.Options;

namespace Company.Data.Contexts;

public class CompanyContext : DbContext
{
    public DbSet<Business> Business => Set<Business>();
    public DbSet<Department> Departmens => Set<Department>(); 
    public DbSet<Employee> Employees => Set<Employee>(); 
    public DbSet<Title> Titles  => Set<Title>(); 
    public DbSet<EmployeeTitle> EmployeeTitles  => Set<EmployeeTitle>(); 

    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
    {

	}
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<EmployeeTitle>().HasKey(et => new { et.EmployeeId, et.TitleId });
        SeedData(builder);
    }
    private void SeedData(ModelBuilder builder)
    {
        var business = new List<Business>
        {
            new Business
            {
             Id = 1,
             Name ="CompanyEuropa",
             OrgNumber = 1001
            },
            new Business
            {
             Id = 2,
             Name ="CompanyNorden",
             OrgNumber = 1002
            },
            new Business
            {
             Id = 3,
             Name ="CompanyAmerica",
             OrgNumber = 1003
            },
            new Business
            {
             Id = 4,
             Name ="CompanyAsia",
             OrgNumber = 1004
            }
        };
        builder.Entity<Business>().HasData(business);

        var department = new List<Department>
        {
            new Department
            {
             Id = 1,
             Name ="ITTeam",
             BusinessId = 1
            },
            new Department
            {
             Id = 2,
             Name ="DevelopTeam",
             BusinessId = 2
            },
            new Department
            {
             Id = 3,
             Name ="AITeam",
             BusinessId = 3
            },
            new Department
            {
             Id = 4,
             Name ="EconomyTeam",
             BusinessId = 4
            },
            new Department
            {
             Id = 5,
             Name ="SpecialistIT",
             BusinessId = 2
            },
            new Department
            {
             Id = 6,
             Name ="DevelopSpecialist",
             BusinessId = 1
            }
        };
        builder.Entity<Department>().HasData(department);

        var employee = new List<Employee>
        {
            new Employee 

            {
             Id = 1,
             FirstName = "Mikael",
             LastName = "Issa",
             Salary = 50.000,
             UnionMember = true,
             DepartmentId = 1,
            },
            
            new Employee
            {
             Id = 2,
            FirstName = "Jack",
             LastName = "Larsson",
             Salary = 500.000,
             UnionMember = false,
             DepartmentId = 2,
            },
            
            new Employee
            {
             Id = 3,
             FirstName = "Sven",
             LastName = "Isaksson",
             Salary = 20.000,
             UnionMember = true,
             DepartmentId = 3,
            },
            new Employee
            {
             Id = 4,
             FirstName = "Ben",
             LastName = "King",
             Salary = 555.000,
             UnionMember = true,
             DepartmentId = 4,
            }
        };
        builder.Entity<Employee>().HasData(employee);

        var title = new List<Title>
        {
            new Title

            {
             Id = 1,
             Role = "CEO"
            },
            new Title

            {
            Id = 2,
             Role = "CTO"
            },
            new Title
            {
           Id = 3,
             Role = "CFO"
            },
            new Title
            {
             Id = 4,
             Role = "Developer"
            },
            new Title
            {
            Id = 5,
             Role = "Tester"
            }
            
        };
        builder.Entity<Title>().HasData(title);

        var employeetitle = new List<EmployeeTitle>
        {
            new EmployeeTitle

            {
             EmployeeId = 1,
             TitleId = 1
            },
            new EmployeeTitle

            {
             EmployeeId = 2,
             TitleId = 1
            },
            new EmployeeTitle
            {
             EmployeeId = 3,
             TitleId = 2
            },
            new EmployeeTitle
            {
             EmployeeId = 4,
             TitleId = 3
            },
            new EmployeeTitle
            {
             EmployeeId = 1,
             TitleId = 4
            }

        };
        builder.Entity<EmployeeTitle>().HasData(employeetitle);
    }

     
}
