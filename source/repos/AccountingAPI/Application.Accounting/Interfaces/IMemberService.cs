using LoanManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApplication.Interfaces
{
    public interface IMemberService
    {
        Task<int> CreateAsync(Member member);
        Task<int> UpdateAsync(Member member);
        Task<int> DeleteAsync(int memberId);
        Task<Member?> GetByIdAsync(int memberId);
        Task<IEnumerable<Member>> GetAllAsync();
        Task<IEnumerable<Member>> SearchByAsync(string? nationalCode, string? fullName);
    }
}
