using LoanManagementSystemApplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApplication.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse?> AuthenticateAsync(string username, string password);
        Task<int> RegisterAsync(string username, string password, string role);
    }
}
