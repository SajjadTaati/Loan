using Dapper;
using LoanManagementSystem.Domain.Entities;
using LoanManagementSystem.Infrastructure.DataBase;
using LoanManagementSystemApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Infrastructure.Repositories
{
    public class LoanRepository : ILoanService
    {
        private readonly DapperContext _context;

        public LoanRepository(DapperContext context)
        {
            _context = context;
        }


        public async Task<int> CreateAsync(Loan loan)
        {
            using var connection = _context.CreateConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                "Loans_Insert",
                commandType: CommandType.StoredProcedure
            );
            return result;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<Loan>(
                "Loans_GetAll",
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
    }
}
