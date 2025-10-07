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
    public class MemberRepository : IMemberService
    {
        private readonly DapperContext _context;

        public MemberRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Member member)
        {
            using var connection = _context.CreateConnection();
            using var InsertMembersnnection = _context.CreateConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                "InsertMembers",
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
      
        public async Task<int> UpdateAsync(Member member)
        {
            using var connection = _context.CreateConnection();
            using var coInsertMembersnnection = _context.CreateConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                "UpdateMembers",
                commandType: CommandType.StoredProcedure
            );
            return result;
        }

        

        public async Task<int> DeleteAsync(int memberId)
        {
            using var connection = _context.CreateConnection();
            using var coInsertMembersnnection = _context.CreateConnection();
            var result = await connection.ExecuteScalarAsync<int>(
                "DeleteMemebers",
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
       
        public async Task<Member?> GetByIdAsync(int memberId)
        {
            using var connection = _context.CreateConnection();
            using var coInsertMembersnnection = _context.CreateConnection();
            var result = await connection.ExecuteScalarAsync<Member>(
                " Members_GetById",
                commandType: CommandType.StoredProcedure
            );
            return result;
        }

        public async Task<IEnumerable<Member>> GetAllAsync()
        {
          
                using var connection = _context.CreateConnection();
            using var coInsertMembersnnection = _context.CreateConnection();
            var result = await connection.QueryAsync<Member>(
                "Members_GetAll",
                commandType: CommandType.StoredProcedure
            );
            return result;


        }

        public  async Task<IEnumerable<Member>> SearchByAsync(string? nationalCode, string? fullName)
        {
            using var connection = _context.CreateConnection();
            using var coInsertMembersnnection = _context.CreateConnection();
            var result = await connection.QueryAsync<Member>(
                "Members_Search",
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
    }
}
