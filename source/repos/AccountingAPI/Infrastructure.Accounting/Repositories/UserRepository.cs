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
            var parameters = new DynamicParameters();
            parameters.Add("@Username", user.Username);
            parameters.Add("@PasswordHash", user.PasswordHash, DbType.Binary);
            parameters.Add("@PasswordSalt", user.PasswordSalt, DbType.Binary);
            parameters.Add("@Role", user.Role);

            var newId = await conn.ExecuteScalarAsync<int>(
                "Users_Insert",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return newId;
        }
    }
}
