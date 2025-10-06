using LoanManagementSystem.Domain.Entities;
using LoanManagementSystemApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApplication.Services
{
    public class LoanService
    {
        private readonly ILoanRepository _repo;

        public LoanService(ILoanRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Loan>> GetLoansAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<int> AddLoanAsync(Loan loan)
        {
            // منطق تجاری مثل اعتبارسنجی یا موجودی صندوق
            return await _repo.CreateAsync(loan);
        }
    }
}
