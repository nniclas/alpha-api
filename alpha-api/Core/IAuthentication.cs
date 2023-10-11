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
    public interface IAuthentication
    {
        User CreateUser(string email, string password);
        bool VerifyUser(User user, string passwordInput);
        string CreateToken(User user, Identity identity);
    }
}
