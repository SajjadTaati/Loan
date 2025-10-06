using LoanManagementSystem.Domain.Entities;
using LoanManagementSystemApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        public Task<int> CreateAsync(Loan loan)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Loan>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
