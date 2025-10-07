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
    public class UserRepository : IUserService
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context) => _context = context;

        public async Task<User?> GetByUsernameAsync(string username)
        {
            using var conn = _context.CreateConnection();
            var user = await conn.QuerySingleOrDefaultAsync<User>(
                "Users_GetByUsername",
                new { Username = username },
                commandType: CommandType.StoredProcedure
            );
            return user;
        }

        public async Task<int> CreateAsync(User user)
        {
            using var conn = _context.CreateConnection();
            var users = await conn.ExecuteScalarAsync<int>(
                "InsertUsers",
            
                commandType: CommandType.StoredProcedure
            );
            return users;
        }
    }
}
