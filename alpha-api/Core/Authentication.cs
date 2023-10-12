using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Authentication;
using Org.BouncyCastle.Asn1.Ocsp;
using alpha_api.Controllers;

namespace alpha_api.Core
{
    public class Authentication : IAuthentication
    {
        public User CreateUser(string email, string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            return new User 
            { 
                Email = email, 
                Hash = hash, 
                Access = "READ", 
                RegisterDate = DateTime.Now 
            };
        }

        public bool VerifyUser(User user, string passwordInput)
        {
            if (user.Hash == null)
                return false;   

            if (BCrypt.Net.BCrypt.Verify(passwordInput, user.Hash))
                return true;

            return false;
        }

        public string CreateToken(User user, Identity identity)
        {
            //create claims details based on the user information
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, identity.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("DisplayName", user.Email),
                    new Claim("UserName", user.Email),
                    new Claim("Email", user.Email)
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(identity.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                identity.Issuer,
                identity.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class Identity
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    }
}
