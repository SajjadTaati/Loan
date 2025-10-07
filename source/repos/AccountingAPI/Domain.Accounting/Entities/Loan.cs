using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public decimal Amount { get;   set; }
        public int InstallmentCount { get;  set; }
        public DateTime StartDate { get; set; }
        public string Status { get;   set; } = "Active";
        public int? CreatedByUserId { get; set; }
    }
}
