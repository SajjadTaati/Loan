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
        private readonly ILoanService _repo;

        public LoanService(ILoanService repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Loan>> GetLoansAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<int> AddLoanAsync(Loan loan)
        {
          
            return await _repo.CreateAsync(loan);
        }
    }
}
