using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApplication.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string NationalCode { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
