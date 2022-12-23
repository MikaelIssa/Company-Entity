using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Common.DTOs
{
    public record EmployeeTitlesDTO
    {
        public int EmployeeId { get; set; }
        public int TitleId { get; set; }
        public EmployeeTitlesDTO(int employeeId, int titleId) 
            => (EmployeeId, TitleId) = (employeeId, titleId);
    }
}
