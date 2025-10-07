
using System;
using LoanManagementSystem.API.utility;
using LoanManagementSystem.Domain.Entities;
using LoanManagementSystemApplication.Dtos;
using LoanManagementSystemApplication.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userRepo;
        private readonly IConfiguration _config;

        public AuthService(IUserService userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task<int> RegisterAsync(string username, string password, string role)
        {
            var existing = await _userRepo.GetByUsernameAsync(username);
            if (existing != null) throw new InvalidOperationException("Username already exists.");

            PasswordHelper.CreatePasswordHash(password, out var hash, out var salt);

            var user = new User
            {
                Username = username,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = role
            };

            return await _userRepo.CreateAsync(user);
        }

        public async Task<AuthResponse?> AuthenticateAsync(string username, string password)
        {
            var user = await _userRepo.GetByUsernameAsync(username);
            if (user == null) return null;

            var valid = PasswordHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (!valid) return null;

            var token = GenerateJwtToken(user);
            return token;
        }

        private AuthResponse GenerateJwtToken(User user)
        {
            var jwtSection = _config.GetSection("JwtSettings");
            var key = jwtSection["Key"] ?? throw new InvalidOperationException("JWT Key not found");
            var issuer = jwtSection["Issuer"];
            var audience = jwtSection["Audience"];
            var expiresMinutes = int.Parse(jwtSection["ExpiresMinutes"]);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.UtcNow.AddMinutes(expiresMinutes);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new AuthResponse(tokenString, expires);
        }
    }
}